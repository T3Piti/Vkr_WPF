using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Vkr_WPF.CustomMessages;
using Vkr_WPF.Models;
using Vkr_WPF.Models.CustomDataModels;
using Vkr_WPF.RelayCommands;

namespace Vkr_WPF.ViewModels.Windows
{
    public class ProjectStageWindowViewModel : INotifyPropertyChanged
    {
        public stage CurrentStage { get; set; }

        #region Actions

        #region show
        public Action<ShortEmployeeModel> ShowEmployeeWindowAction { get; set; }
        public Action<task> ShowTaskWindowAction { get; set; }
        public Action<document> ShowDocumentWindowAction { get; set; }
        #endregion

        #region add
        public Action<ProjectStageWindowViewModel> ShowAddTaskWindowAction { get; set; }
        public Action<ProjectStageWindowViewModel> ShowAddDocumentWindowAction { get; set; }
        #endregion

        #endregion

        #region Bindings

        #region search boxes
        private string searchEmployee;
        public string SearchEmployee { get => searchEmployee; set { searchEmployee = value; OnPropertyChanged(); } }

        private string searchTask;
        public string SearchTask
        {
            get => searchTask; set
            {
                searchTask = value;
                if (value != String.Empty)
                    LoadTasks(value);
                else
                    LoadTasks();
                OnPropertyChanged();
            }
        }

        private string searchDocument;
        public string SearchDocument
        {
            get => searchDocument; set
            {
                searchDocument = value;
                if (value != String.Empty)
                    LoadDocuments(value);
                else
                    LoadDocuments();
                OnPropertyChanged();
            }
        }
        #endregion

        #region Collections
        public ObservableCollection<task> TasksList { get; set; }
        public ObservableCollection<document> DocumentsList { get; set; }
        public ObservableCollection<ShortEmployeeModel> EmployeesList { get; set; }
        #endregion

        #region Selected items
        private task selectedTask;
        public task SelectedTask { get => selectedTask; set { selectedTask = value; OnPropertyChanged(); } }

        private document selectedDocument;
        public document SelectedDocument { get => selectedDocument; set { selectedDocument = value; OnPropertyChanged(); } }

        private ShortEmployeeModel selectedEmployee;
        public ShortEmployeeModel SelectedEmployee { get => selectedEmployee; set { selectedEmployee = value; OnPropertyChanged(); } }
        #endregion

        #endregion

        #region Commands

        #region show
        private RelayCommand showEmployeeWindowCommand;
        public RelayCommand ShowEmployeeWindowCommand => showEmployeeWindowCommand ?? (showEmployeeWindowCommand = new RelayCommand(ShowEmployeeWindow, CanShowEmployeeWindow));

        private RelayCommand showTaskWindowCommand;
        public RelayCommand ShowTaskWindowCommand => showTaskWindowCommand ?? (showTaskWindowCommand = new RelayCommand(ShowTaskWindow, CanShowTaskWindow));

        private RelayCommand showDocumentWindowCommand;
        public RelayCommand ShowDocumentWindowCommand => showDocumentWindowCommand ?? (showDocumentWindowCommand = new RelayCommand(ShowDocumentWindow, CanShowDocumentwindow));
        #endregion

        #region add
        private RelayCommand showAddTaskWindowCommand;
        public RelayCommand ShowAddTaskWindowCommand => showAddTaskWindowCommand ?? (showAddTaskWindowCommand = new RelayCommand(ShowAddTaskWindow, CanShowAddTaskWindow));

        private RelayCommand showAddDocumentWindowCommand;
        public RelayCommand ShowAddDocumentWindowCommand => showAddDocumentWindowCommand ?? (showAddDocumentWindowCommand = new RelayCommand(ShowAddDocumentWindow, CanShowAddDocumentWindow));
        #endregion

        #region delete
        private RelayCommand deleteTaskCommand;
        public RelayCommand DeleteTaskCommand => deleteTaskCommand ?? (deleteTaskCommand = new RelayCommand(DeleteTask, CanDeleteTask));

        private RelayCommand deleteDocumentCommand;
        public RelayCommand DeleteDocumentCommand => deleteDocumentCommand ?? (deleteDocumentCommand = new RelayCommand(DeleteDocument, CanDeleteDocument));
        #endregion

        #endregion

        #region Methods

        #region do commands

        #region delete
        private void DeleteDocument(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _document = db.documents.Find(SelectedDocument.id);
                    db.documents.Remove(_document);
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
        private void DeleteTask(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _task = db.tasks.Find(SelectedTask.id);
                    db.tasks.Remove(_task);
                    db.SaveChanges();
                }
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Задание успешно удалено", "Удаление задания", "information");
                LoadTasks();
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка удаления задания", "error");
            }
        }
        #endregion

        #region add
        private void ShowAddDocumentWindow(object obj) => ShowAddDocumentWindowAction(this);
        private void ShowAddTaskWindow(object obj) => ShowAddTaskWindowAction(this);
        #endregion

        #region show
        private void ShowDocumentWindow(object obj) => ShowDocumentWindowAction(SelectedDocument);
        private void ShowTaskWindow(object obj) => ShowTaskWindowAction(SelectedTask);
        private void ShowEmployeeWindow(object obj) => ShowEmployeeWindowAction(SelectedEmployee);
        #endregion

        #endregion

        #region can do commands

        #region delete
        private bool CanDeleteDocument(object arg)
        {
            if (SelectedDocument != null)
                return true;
            return false;
        }
        private bool CanDeleteTask(object arg)
        {
            if (SelectedTask != null)
                return true;
            return false;
        }
        #endregion

        #region add
        private bool CanShowAddTaskWindow(object arg)
        {
            if (SelectedTask != null)
                return true;
            return false;
        }
        private bool CanShowAddDocumentWindow(object arg)
        {
            if (SelectedDocument != null)
                return true;
            return false;
        }
        #endregion

        #region show
        private bool CanShowDocumentwindow(object arg)
        {
            if (SelectedDocument != null)
                return true;
            return false;
        }
        private bool CanShowTaskWindow(object arg)
        {
            if (SelectedTask != null)
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

        #endregion

        #region load
        public void LoadTasks()
        {
            TasksList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _tasks = db.tasks.Where(t => t.stage_id == CurrentStage.id).ToList();
                    foreach (var _task in _tasks)
                        TasksList.Add(_task);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки заданий", "error");
            }
        }
        public void LoadTasks(string search)
        {
            TasksList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _tasks = db.tasks.Where(t => t.stage_id == CurrentStage.id && t.name.Contains(search)).ToList();
                    foreach (var _task in _tasks)
                        TasksList.Add(_task);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки заданий", "error");
            }
        }
        public void LoadDocuments()
        {
            DocumentsList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _documents = db.project_has_document.Where(pd => pd.stage_id == CurrentStage.id);
                    foreach (var _document in _documents)
                        DocumentsList.Add(_document.document);
                }
            }
            catch (Exception ex)
            {

                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки документов", "error");
            }
        }
        public void LoadDocuments(string search)
        {
            DocumentsList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _documents = db.project_has_document.Where(pd => pd.stage_id == CurrentStage.id && pd.document.name.Contains(search));
                    foreach (var _document in _documents)
                        DocumentsList.Add(_document.document);
                }
            }
            catch (Exception ex)
            {

                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки документов", "error");
            }
        }
        public void LoadEmployees()
        {
            EmployeesList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _employees = db.task_has_employees.Where(t => t.task.stage_id == CurrentStage.id);
                    foreach (var _employee in _employees)
                        EmployeesList.Add(new ShortEmployeeModel
                        {
                            Name = _employee.users_info.name,
                            SecondName = _employee.users_info.second_name,
                            Patronymic = _employee.users_info.patronymic,
                            Id = _employee.users_info.id,
                            Department = _employee.users_info.department.name,
                            DepartmentId = _employee.users_info.department_id
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

        #endregion

        public ProjectStageWindowViewModel(stage currentStage)
        {
            CurrentStage = currentStage;
            TasksList = new ObservableCollection<task>();
            DocumentsList = new ObservableCollection<document>();
            EmployeesList = new ObservableCollection<ShortEmployeeModel>();
            LoadTasks();
            LoadDocuments();
            LoadEmployees();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
