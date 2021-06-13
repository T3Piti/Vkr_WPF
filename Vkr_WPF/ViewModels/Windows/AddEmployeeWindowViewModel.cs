using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Vkr_WPF.CustomMessages;
using Vkr_WPF.Models;
using Vkr_WPF.Models.CustomDataModels;
using Vkr_WPF.RelayCommands;
using Vkr_WPF.ViewModels.Pages;

namespace Vkr_WPF.ViewModels.Windows
{
    public class AddEmployeeWindowViewModel : INotifyPropertyChanged
    {
        private TaskWindowViewModel TaskWindowVM { get; set; }
        private ProjectPageViewModel ProjectPageVM { get; set; }

        public ObservableCollection<ShortEmployeeModel> EmployeesList { get; set; }

        private ShortEmployeeModel selectedEmployee;
        public ShortEmployeeModel SelectedEmployee { get => selectedEmployee; set { selectedEmployee = value; OnPropertyChanged(); } }

        public Action<ShortEmployeeModel> ShowEmployeeWindowAction { get; set; }

        #region Commands
        private RelayCommand showEmployeWindowCommand;
        public RelayCommand ShowEmployeWindowCommand => showEmployeWindowCommand ?? (showEmployeWindowCommand = new RelayCommand(ShowEmployeeWindow, CanShowEmployeeWindow));

        private RelayCommand addEmployeeCommand;
        public RelayCommand AddEmployeeCommand => addEmployeeCommand ?? (addEmployeeCommand = new RelayCommand(AddEmployee, CanAddEmployee));

        #endregion


        #region Methods

        #region do commands
        private void AddEmployee(object obj)
        {
            if (this.TaskWindowVM != null)
                AddEmployeeToTask();
            else
                AddEmployeeToProject();
        }
        private void ShowEmployeeWindow(object obj) => ShowEmployeeWindowAction(SelectedEmployee);
        #endregion

        #region can do commands
        private bool CanAddEmployee(object arg)
        {
            if (SelectedEmployee != null)
                return true;
            return false;
        }
        private bool CanShowEmployeeWindow(object arg)
        {
            if (SelectedEmployee != null)
                return true;
            return false;
        }
        #endregion

        #region load
        private void LoadEmployees()
        {
            EmployeesList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _employeesAtptoject = db.project_has_employees.Where(p => p.project_id == this.ProjectPageVM.CurrentProject.id);
                    var _employees = db.users_info.ToList();
                    foreach (var _e in _employeesAtptoject)
                        _employees.Remove(_e.users_info);
                    foreach (var _employee in _employees)
                        EmployeesList.Add(new ShortEmployeeModel
                        {
                            Id = _employee.id,
                            Name = _employee.name,
                            SecondName = _employee.second_name,
                            Patronymic = _employee.patronymic,
                            DepartmentId = _employee.department_id,
                            Department = _employee.department.name
                        });
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки сотрудников", "error");
            }
        }
        private void LoadEmployeesAtProject()
        {
            EmployeesList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _employees = db.project_has_employees.Where(pe => pe.project_id == TaskWindowVM.CurrentTask.stage.project_id).ToList();
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
        #endregion

        #region add
        private void AddEmployeeToProject()
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    db.project_has_employees.Add(new project_has_employees { 
                    user_info_id=SelectedEmployee.Id,
                    project_id = this.ProjectPageVM.CurrentProject.id
                    });
                    db.SaveChanges();
                }
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Сотрудник добавлен к проекту", "Добавление сотрудника к проекту", "information");
                this.LoadEmployees();
                this.ProjectPageVM.LoadEmployees();
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка добавления сотрудника к проекту", "error");
            }
        }
        private void AddEmployeeToTask()
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    db.task_has_employees.Add(new task_has_employees
                    {
                        user_info_id = SelectedEmployee.Id,
                        task_id = this.TaskWindowVM.CurrentTask.id
                    });
                    db.SaveChanges();
                }
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Сотрудник добавлен к заданию", "Добавление сотрудника к заданию", "information");
                this.LoadEmployeesAtProject();
                this.TaskWindowVM.LoadEmployees();
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка добавления сотрудника к заданию", "error");
            }
        }
        #endregion

        #endregion

        #region Сonstructors
        public AddEmployeeWindowViewModel(TaskWindowViewModel vm)
        {
            this.TaskWindowVM = vm;
            EmployeesList = new ObservableCollection<ShortEmployeeModel>();
            LoadEmployeesAtProject();
        }

        public AddEmployeeWindowViewModel(ProjectPageViewModel vm)
        {
            this.ProjectPageVM = vm;
            EmployeesList = new ObservableCollection<ShortEmployeeModel>();
            LoadEmployees();
        }
        #endregion



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
