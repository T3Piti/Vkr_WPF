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

namespace Vkr_WPF.ViewModels.Pages
{
    public class ProjectPageViewModel : INotifyPropertyChanged
    {
        public project CurrentProject { get; set; }

        #region Actions

        #region show
        public Action<ShortEmployeeModel> ShowEmployeeWindowAction { get; set; }
        public Action<document> ShowDocumentWindowAction { get; set; }
        public Action<stage> ShowProjectStageWindowAction { get; set; }
        #endregion

        #region add
        public Action<ProjectPageViewModel> ShowAddStageWindowAction { get; set; }
        public Action<ProjectPageViewModel> ShowAddDocumentWindowAction { get; set; }
        public Action<ProjectPageViewModel> ShowAddEmployeeWindowAction { get; set; }
        #endregion

        #endregion

        #region Bindings

        #region Collections
        public ObservableCollection<ShortEmployeeModel> EmployeesList;
        public ObservableCollection<stage> StagesList;
        public ObservableCollection<document> DocumentsList;
        #endregion

        #region selected items
        private ShortEmployeeModel selectedEmployee;
        public ShortEmployeeModel SelectedEmployee { get => selectedEmployee; set { selectedEmployee = value; OnPropertyChanged(); } }

        private stage selectedStage;
        public stage SelectedStage { get => selectedStage; set { selectedStage = value; OnPropertyChanged(); } }

        private document selectedDocument;
        public document SelectedDocument { get => selectedDocument; set { selectedDocument = value; OnPropertyChanged(); } }
        #endregion

        #region search
        private string searchEmployeeString;
        public string SearchEmployeeString { get => searchEmployeeString;
            set {
                searchEmployeeString = value;
                OnPropertyChanged();
            }
        }

        private string searchStageString;
        public string SearchStageString { get => searchStageString;
            set {
                searchStageString = value;
                if (value != String.Empty)
                    LoadStages(value);
                else
                    LoadStages();
                OnPropertyChanged();
            }
        }

        private string seacrhDocumentString;
        public string SeacrhDocumentString { get => seacrhDocumentString;
            set {
                seacrhDocumentString = value;
                if (value != null)
                    LoadDocuments(value);
                else
                    LoadDocuments();
                OnPropertyChanged();
            }
        }
        #endregion
        #endregion

        #region Commands

        #region show
        private RelayCommand showEmployeeWindowCommand;
        public RelayCommand ShowEmployeeWindowCommand => showEmployeeWindowCommand ?? (showEmployeeWindowCommand = new RelayCommand(ShowEmployeeWindow, CanShowEmplyeeWindow));

        private RelayCommand showDocumentWindowCommnd;
        public RelayCommand ShowDocumentWindowCommnd => showDocumentWindowCommnd ?? (showDocumentWindowCommnd = new RelayCommand(ShowDocumentWindow, CanShowDocumentWindow));

        private RelayCommand showPojectStageWindowCommand;
        public RelayCommand ShowPojectStageWindowCommand => showPojectStageWindowCommand ?? (showPojectStageWindowCommand = new RelayCommand(ShowProjectStageWindow, CanShowProjectStageWindow));
        #endregion

        #region delete
        private RelayCommand deleteStageCommand;
        public RelayCommand DeleteStageCommand => deleteStageCommand ?? (deleteStageCommand = new RelayCommand(DeleteStage, CanDeleteStage));

        private RelayCommand deleteEmployeeCommand;
        public RelayCommand DeleteEmployeeCommand => deleteEmployeeCommand ?? (deleteEmployeeCommand = new RelayCommand(DeleteEmployee, CanDeleteEmployee));

        private RelayCommand deleteDocumentCommand;
        public RelayCommand DeleteDocumentCommand => deleteDocumentCommand ?? (deleteDocumentCommand = new RelayCommand(DeleteDocument, CanDeleteDocument));
        #endregion

        #region add
        private RelayCommand showAddstageWindowCommand;
        public RelayCommand ShowAddstageWindowCommand => showAddstageWindowCommand ?? (showAddstageWindowCommand = new RelayCommand(ShowAddStage));

        private RelayCommand showAddDocumentWindowCommand;
        public RelayCommand ShowAddDocumentWindowCommand => showAddDocumentWindowCommand ?? (showAddDocumentWindowCommand = new RelayCommand(ShowAddDocumentWindow));

        private RelayCommand showAddEmployeeWindowCommand;
        public RelayCommand ShowAddEmployeeWindowCommand => showAddEmployeeWindowCommand ?? (showAddEmployeeWindowCommand = new RelayCommand(ShowAddEmployeeWindow));
        #endregion

        #endregion

        #region Methods

        #region do commands

        #region show
        private void ShowProjectStageWindow(object obj) => ShowProjectStageWindowAction(SelectedStage);
        private void ShowDocumentWindow(object obj) => ShowDocumentWindowAction(SelectedDocument);
        private void ShowEmployeeWindow(object obj) => ShowEmployeeWindowAction(SelectedEmployee);
        #endregion

        #region delete
        private void DeleteDocument(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _documentsIds = db.project_has_document.Where(d => d.project_id==CurrentProject.id).ToList();
                    var documents = new List<document>();
                    foreach (var docId in _documentsIds)
                        documents.Add(db.documents.Where(d=> d.id == docId.id).FirstOrDefault());
                    foreach (var doc in documents)
                        db.documents.Remove(doc);
                    db.SaveChanges();
                }
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Документ успешно удален", "Удаление документа", "information");
                LoadDocuments();
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка удаления документа", "error");
            }
        }
        private void DeleteStage(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _stage = db.stages.Find(SelectedStage.id);
                    db.stages.Remove(_stage);
                    db.SaveChanges();
                }
                LoadStages();
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Этап успешно удален", "Удаление этапа", "information");
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка удаления этапа", "error");
            }
        }
        private void DeleteEmployee(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _employee = db.project_has_employees.Where(pe => pe.user_info_id == SelectedEmployee.Id && pe.project_id==CurrentProject.id).FirstOrDefault();
                    db.project_has_employees.Remove(_employee);
                    var _employeeAtTasks = db.task_has_employees.Where(te => te.user_info_id==selectedEmployee.Id && te.task.stage.project_id==CurrentProject.id).ToList();
                    foreach (var employee in _employeeAtTasks)
                        db.task_has_employees.Remove(employee);
                    db.SaveChanges();
                }
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Сотрудник успешно убран из проекта", "Удаление сотрудника", "information");
                LoadEmployees();
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка удаления сотрудника", "error");
            }
        }
        #endregion

        #region add
        private void ShowAddEmployeeWindow(object obj) => ShowAddEmployeeWindowAction(this);
        private void ShowAddDocumentWindow(object obj) => ShowAddDocumentWindowAction(this);
        private void ShowAddStage(object obj) => ShowAddStageWindowAction(this);
        #endregion

        #endregion

        #region can do commands

        #region show
        private bool CanShowProjectStageWindow(object arg)
        {
            if (SelectedStage != null)
                return true;
            return false;
        }
        private bool CanShowDocumentWindow(object arg)
        {
            if (SelectedDocument != null)
                return true;
            return false;
        }
        private bool CanShowEmplyeeWindow(object arg)
        {
            if (SelectedEmployee != null)
                return true;
            return false;
        }
        #endregion

        #region delete
        private bool CanDeleteDocument(object arg)
        {
            if (SelectedDocument != null)
                return true;
            return false;
        }
        private bool CanDeleteEmployee(object arg)
        {
            if (SelectedEmployee != null)
                return true;
            return false;
        }
        private bool CanDeleteStage(object arg)
        {
            if (SelectedStage != null)
                return true;
            return false;
        }
        #endregion

        #endregion

        #region load collections
        public void LoadStages()
        {
            StagesList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _stages = db.stages.Where(s => s.project_id==CurrentProject.id).ToList();
                    foreach (var stage in _stages)
                        StagesList.Add(stage);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки данных", "error");
            }
        }
        public void LoadEmployees()
        {
            EmployeesList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var employeesAtProject = db.project_has_employees.Where(pe => pe.project_id==CurrentProject.id).ToList();
                    var _employees = new List<users_info>();
                    foreach (var eAtProject in employeesAtProject)
                        _employees.Add(db.users_info.Find(eAtProject.user_info_id));
                    foreach (var _employee in _employees)
                        EmployeesList.Add(new ShortEmployeeModel {
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
                msb.ShowMessage(ex.Message, "Ошибка загрузки данных", "error");
            }
        }
        public void LoadDocuments()
        {
            DocumentsList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _documentsAtProject = db.project_has_document.Where(dp => dp.project_id==CurrentProject.id).ToList();
                    foreach (var doc in _documentsAtProject)
                        DocumentsList.Add(db.documents.Where(d=> d.id == doc.document_id).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки данных", "error");
            }
        }
        private void LoadDocuments(string search)
        {
            DocumentsList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _documentsAtProject = db.project_has_document.Where(dp => dp.project_id == CurrentProject.id).ToList();
                    foreach (var doc in _documentsAtProject)
                        DocumentsList.Add(db.documents.Where(d => d.id == doc.document_id && d.name.Contains(search)).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки данных", "error");
            }
        }
        private void LoadStages(string search)
        {
            StagesList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _stages = db.stages.Where(s => s.project_id == CurrentProject.id && s.name.Contains(search)).ToList();
                    foreach (var stage in _stages)
                        StagesList.Add(stage);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки данных", "error");
            }
        }
        #endregion
        #endregion

        public ProjectPageViewModel(project currentProject)
        {
            StagesList = new ObservableCollection<stage>();
            EmployeesList = new ObservableCollection<ShortEmployeeModel>();
            DocumentsList = new ObservableCollection<document>();
            this.CurrentProject = currentProject;
            LoadStages();
            LoadEmployees();
            LoadDocuments();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
