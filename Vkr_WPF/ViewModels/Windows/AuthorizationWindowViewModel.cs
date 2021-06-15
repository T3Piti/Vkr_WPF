using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Vkr_WPF.CustomMessages;
using Vkr_WPF.Models;
using Vkr_WPF.RelayCommands;
using Vkr_WPF.UserInfoStatic;

namespace Vkr_WPF.ViewModels.Windows
{
    public class AuthorizationWindowViewModel : INotifyPropertyChanged
    {
        #region Actions
        public Action<user> ShowMainWindowAction { get; set; }
        public Action CloseCurrentWindowAction { get; set; }
        #endregion

        #region Bindings
        private string login;
        public string Login { get => login; set { login = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        private RelayCommand authenticateCommand;
        public RelayCommand AuthenticateCommand => authenticateCommand ?? (authenticateCommand = new RelayCommand(Authenticate, CanAuthenticate));


        #endregion

        #region Commands methods
        
        #region Do methods
        private void Authenticate(object obj)
        {
            PasswordBox pwb = obj as PasswordBox;
            try
            {
                using (var db = new DocsdbContext())
                {
                    var userModel = db.users.Where(u => u.id == Login && u.password == pwb.Password).FirstOrDefault();
                    if (userModel != null)
                    {
                        UserData.User = db.users_info.Where(u => u.user_id==userModel.id).FirstOrDefault();
                        ShowMainWindowAction(userModel);
                        CloseCurrentWindowAction();
                    }
                    else
                    {
                        CustomMessageBox cmsb = new CustomMessageBox();
                        cmsb.ShowMessage("Логин или пароль введены неверно", "Ошибка авторизации", "error");
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox cmsb = new CustomMessageBox();
                cmsb.ShowMessage(ex.Message, "Ошибка авторизации", "error");
            }
        }
        #endregion

        #region Can do Methods
        private bool CanAuthenticate(object arg)
        {
            PasswordBox password = arg as PasswordBox;
            if (password.Password != String.Empty && Login != String.Empty)
                return true;
            return false;
        }
        #endregion
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
