using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vkr_WPF.CustomMessages;
using Vkr_WPF.Models;
using Vkr_WPF.Models.CustomDataModels;

namespace Vkr_WPF.ViewModels.Windows
{
    public class EmployeeWindowViewModel : INotifyPropertyChanged
    {
        #region Bindings

        #region user info
        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }

        private string secondName;
        public string SecondName { get => secondName; set { secondName = value; OnPropertyChanged(); } }

        private string patronymic;
        public string Patronymic { get => patronymic; set { patronymic = value; OnPropertyChanged(); } }

        private string department;
        public string Department { get => department; set { department = value; OnPropertyChanged(); } }
        #endregion

        #region collections
        public ObservableCollection<project> ProjectsList { get; set; }
        public ObservableCollection<task> TasksList { get; set; }
        #endregion

        #endregion

        public EmployeeWindowViewModel(ShortEmployeeModel employee)
        {
            ProjectsList = new ObservableCollection<project>();
            TasksList = new ObservableCollection<task>();
            SetUserInfo(employee);
            LoadProjects(employee);
            LoadTasks(employee);
        }

        private void LoadTasks(ShortEmployeeModel employee)
        {
            TasksList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _employeeTasks = db.task_has_employees.Where(t=> t.user_info_id == employee.Id && t.task.status_id==3).ToList();
                    foreach (var _task in _employeeTasks)
                        TasksList.Add(_task.task);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки информации", "error");
            }
        }


        #region Methods
        private void LoadProjects(ShortEmployeeModel employee)
        {
            ProjectsList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _employeeProjects = db.project_has_employees.Where(pe => pe.user_info_id == employee.Id).ToList();
                    foreach (var empProject in _employeeProjects)
                        ProjectsList.Add(empProject.project);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки информации", "error");
            }
        }
        private void SetUserInfo(ShortEmployeeModel employee)
        {
            Name = employee.Name;
            SecondName = employee.SecondName;
            Patronymic = employee.Patronymic;
            Department = employee.Department;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
