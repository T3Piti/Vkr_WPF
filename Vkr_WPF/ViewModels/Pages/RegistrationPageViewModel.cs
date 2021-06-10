using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using Vkr_WPF.CustomMessages;
using Vkr_WPF.Models;
using Vkr_WPF.RelayCommands;

namespace Vkr_WPF.ViewModels.Pages
{
    public class RegistrationPageViewModel : INotifyPropertyChanged
    {
        #region Bindings

        #region user info
        private string login;
        public string Login { get => login; set { login = value; OnPropertyChanged(); } }

        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }

        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }

        private string secondName;
        public string SecondName { get => secondName; set { secondName = value; OnPropertyChanged(); } }

        private string patronymic;
        public string Patronymic { get => patronymic; set { patronymic = value; OnPropertyChanged(); } }

        private string eMail;
        public string EMail { get => eMail; set { eMail = value; OnPropertyChanged(); } }

        private department selectedDepartment;
        public department SelectedDepartment { get => selectedDepartment; set { selectedDepartment = value; OnPropertyChanged(); } }

        private role selectedRole;
        public role SelectedRole { get => selectedRole; set { selectedRole = value; OnPropertyChanged(); } }
        #endregion user info

        #region Collections
        public ObservableCollection<department> DepartmentsList { get; set; }
        public ObservableCollection<role> RolesList { get; set; }
        #endregion
        #endregion

        #region Commands
        private RelayCommand registrateEmployeeCommand;
        public RelayCommand RegistrateEmployeeCommand => registrateEmployeeCommand ?? (registrateEmployeeCommand = new RelayCommand(RegistrateEmployee, CanRegistrateEmployee));
        #endregion

        public RegistrationPageViewModel()
        {
            DepartmentsList = new ObservableCollection<department>();
            RolesList = new ObservableCollection<role>();
            FillDepartmentsList();
            FillRolesList();
        }

        #region Methods
        private bool EmailIsEnable()
        {
            using (var db = new DocsdbContext())
            {
                var email = db.emails.Where(e => e.email1 == EMail).FirstOrDefault();
                if (email == null)
                    return true;
                return false;
            }
        }
        private bool LoginIsEnable()
        {
            using (var db = new DocsdbContext())
            {
                var user = db.users.Find(Login);
                if (user == null)
                    return true;
                return false;
            }
        }
        private void SendEmailMessage()
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("rghostnub@mail.ru");
            // кому отправляем
            MailAddress to = new MailAddress(EMail);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Регистрация";
            // текст письма
            m.Body = $"<h2>Логин: {Login}</h2> <h2>Пароль: {Password}</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("rghostnub@mail.ru", "kovka-sovka");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        #region Commands methods

        #region do commands
        private void RegistrateEmployee(object obj)
        {
            var emailIsEnable = EmailIsEnable();
            var loginIsEnable = LoginIsEnable();
            try
            {
                if (emailIsEnable && loginIsEnable)
                {
                    using (var db = new DocsdbContext())
                    {
                        db.users.Add(new user
                        {
                            id = Login,
                            password = Password,
                            role_id = selectedRole.id
                        });
                        db.users_info.Add(new users_info
                        {
                            name = Name,
                            second_name = SecondName,
                            patronymic = Patronymic,
                            department_id = SelectedDepartment.id,
                            user_id = Login
                        });
                        db.SaveChanges();
                        CustomMessageBox msb = new CustomMessageBox();
                        msb.ShowMessage("Пользователь успешно зарегистрирован\n Логин и пароль отправлены на почту", "Регистрация", "information");
                        SendEmailMessage();
                    }
                }
                else
                {
                    CustomMessageBox msb = new CustomMessageBox();
                    if (emailIsEnable)
                        msb.ShowMessage(message: "Данная почта уже используется", header: "Ошибка регистрации", "error");
                    msb.ShowMessage(message: "Данный логин уже используется", header: "Ошибка регистрации", "error");
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(message: ex.Message, header: "Ошибка регистрации", "error");
            }
        }
        #endregion

        #region can do commands
        private bool CanRegistrateEmployee(object arg)
        {
            if (Login != String.Empty && Password != String.Empty
                && Name != String.Empty && SecondName != String.Empty && Patronymic != String.Empty
                && EMail != String.Empty
                && SelectedDepartment != null && SelectedRole != null)
                return true;
            return false;
        }
        #endregion

        #endregion

        #region Fill methods
        private void FillRolesList()
        {
            RolesList.Clear();
            using (var db = new DocsdbContext())
            {
                var roles = db.roles.ToList();
                foreach (var role in roles)
                    RolesList.Add(role);
            }
        }
        private void FillDepartmentsList()
        {
            DepartmentsList.Clear();
            using (var db = new DocsdbContext())
            {
                var departments = db.departments.ToList();
                foreach (var dep in departments)
                    DepartmentsList.Add(dep);
            }
        }
        #endregion
        #endregion 

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
