using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Vkr_WPF.CustomMessages;
using Vkr_WPF.Models;
using Vkr_WPF.Models.CustomDataModels;
using Vkr_WPF.RelayCommands;

namespace Vkr_WPF.ViewModels.Windows
{
    public class TaskWindowViewModel : INotifyPropertyChanged
    {
        private task CurrentTask { get; set; }

        #region Actions
        public Action<ShortEmployeeModel> ShowEmployeeWindowAction { get; set; }
        public Action<TaskWindowViewModel> ShowAddEmployeeWindowAction { get; set; }
        #endregion

        #region Bindings

        #region task info
        private string taskName;
        public string TaskName { get => taskName; set { taskName = value; OnPropertyChanged(); } }

        private string taskDescription;
        public string TaskDescription { get => taskDescription; set { taskDescription = value; OnPropertyChanged(); } }
        #endregion

        #region collections
        public ObservableCollection<ShortEmployeeModel> EmployeesList { get; set; }
        #endregion

        #region selected items
        private ShortEmployeeModel selectedEmployee;
        public ShortEmployeeModel SelectedEmployee { get => selectedEmployee; set { selectedEmployee = value; OnPropertyChanged(); } }
        #endregion

        #region search box
        private string searchEmployee;
        public string SearchEmployee { get => searchEmployee; set { searchEmployee = value; OnPropertyChanged(); } }
        #endregion

        #region visibility
        private Visibility editDescriptionVisibility;
        public Visibility EditDescriptionVisibility { get => editDescriptionVisibility; set { editDescriptionVisibility = value; OnPropertyChanged(); } }

        private Visibility saveDescriptionVisibility;
        public Visibility SaveDescriptionVisibility { get => saveDescriptionVisibility; set { saveDescriptionVisibility = value; OnPropertyChanged(); } }
        #endregion

        private bool descriptionIsReadOnly;
        public bool DescriptionIsReadOnly { get => descriptionIsReadOnly; set { descriptionIsReadOnly = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        private RelayCommand editDescriptionCommand;
        public RelayCommand EditDescriptionCommand => editDescriptionCommand ?? (editDescriptionCommand = new RelayCommand(EditDescription, CanEditDescription));

        private RelayCommand saveDescriptionCommand;
        public RelayCommand SaveDescriptionCommand => saveDescriptionCommand ?? (saveDescriptionCommand = new RelayCommand(SaveDiscription, CanSaveDescription));

        private RelayCommand showEmployeeWindowCommand;
        public RelayCommand ShowEmployeeWindowCommand => showEmployeeWindowCommand ?? (showEmployeeWindowCommand = new RelayCommand(ShowEmployeeWindow, CanShowEmployeeWindow));

        private RelayCommand showAddEmployeeWindowCommand;
        public RelayCommand ShowAddEmployeeWindowCommand => showAddEmployeeWindowCommand ?? (showAddEmployeeWindowCommand = new RelayCommand(ShowAddEmployeeWindow, CanShowAddEmployeeWindow));

        private RelayCommand deleteEmployeeCommand;
        public RelayCommand DeleteEmployeeCommand => deleteEmployeeCommand ?? (deleteEmployeeCommand = new RelayCommand(DeleteEmployee, CanDeleteEmployee));
        #endregion

        #region Methods

        #region do commands
        private void DeleteEmployee(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _employee = db.task_has_employees.Where(e => e.user_info_id==SelectedEmployee.Id && e.task_id == CurrentTask.id).FirstOrDefault();
                    db.task_has_employees.Remove(_employee);
                    db.SaveChanges();
                }
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Сотрудник удален", "Удаление сотрудника", "error");
                LoadEmployees();
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка удаления сотрудника", "error");
            }
        }
        private void ShowAddEmployeeWindow(object obj) => ShowAddEmployeeWindowAction(this);
        private void ShowEmployeeWindow(object obj) => ShowEmployeeWindowAction(SelectedEmployee);
        private void SaveDiscription(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _task = db.tasks.Find(CurrentTask.id);
                    _task.description = TaskDescription;
                    db.SaveChanges();
                    CurrentTask = _task;
                }
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Изменения сохранены", "Сохранение изменений", "information");
                SetTaskInfo();
                EditDescriptionVisibility = Visibility.Visible;
                SaveDescriptionVisibility = Visibility.Collapsed;
                DescriptionIsReadOnly = true;
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка сохранения изменений", "error");
            }
        }
        private void EditDescription(object obj)
        {
            DescriptionIsReadOnly = false;
            EditDescriptionVisibility = Visibility.Collapsed;
            SaveDescriptionVisibility = Visibility.Visible;
        }
        #endregion

        #region can do commands
        private bool CanDeleteEmployee(object arg)
        {
            if (SelectedEmployee != null)
                return true;
            return false;
        }
        private bool CanShowAddEmployeeWindow(object arg)
        {
            if (SelectedEmployee != null)
                return true;
            return false;
        }
        private bool CanShowEmployeeWindow(object arg)
        {
            if(SelectedEmployee!=null)
                return true;
            return false;
        }
        private bool CanSaveDescription(object arg)
        {
            if (TaskDescription != String.Empty)
                return true;
            return false;
        }
        private bool CanEditDescription(object arg)
        {
            if (SaveDescriptionVisibility == Visibility.Collapsed && DescriptionIsReadOnly)
                return true;
            return false;
        }
        #endregion

        #region load info
        public void LoadEmployees()
        {
            EmployeesList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _employees = db.task_has_employees.Where(e => e.task_id == CurrentTask.id).ToList();
                    foreach (var _employee in _employees)
                        EmployeesList.Add(new ShortEmployeeModel
                        {
                            Id = _employee.users_info.id,
                            Name = _employee.users_info.name,
                            SecondName = _employee.users_info.second_name,
                            Patronymic = _employee.users_info.patronymic,
                            DepartmentId = _employee.users_info.department_id,
                            Department = _employee.users_info.department.name
                        });
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки сотрудников", "error");
            }
        }
        private void SetTaskInfo()
        {
            TaskName = CurrentTask.name;
            TaskDescription = CurrentTask.description;
        }
        #endregion

        #endregion

        public TaskWindowViewModel(task currentTask)
        {
            CurrentTask = currentTask;
            EmployeesList = new ObservableCollection<ShortEmployeeModel>();
            LoadEmployees();
            SetTaskInfo();
            SaveDescriptionVisibility = Visibility.Collapsed;
            EditDescriptionVisibility = Visibility.Visible;
            DescriptionIsReadOnly = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
