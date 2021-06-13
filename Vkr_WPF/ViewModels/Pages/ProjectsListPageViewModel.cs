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
using Vkr_WPF.RelayCommands;
using Vkr_WPF.ViewModels.Windows;

namespace Vkr_WPF.ViewModels.Pages
{
    public class ProjectsListPageViewModel : INotifyPropertyChanged
    {
        private MainWindowViewModel MainWindowVM;

        #region Bindings

        #region Search
        private string searhString;
        public string SearhString { get => searhString; 
            set {
                searhString = value;
                if (value != String.Empty)
                    LoadProjects(value);
                else
                    LoadProjects();
                OnPropertyChanged();
            } }
        #endregion

        #region Collections
        public ObservableCollection<project> ProjectList { get; set; }
        #endregion

        #region selected items
        private project selectedProject;
        public project SelectedProject { get => selectedProject; set { selectedProject = value; OnPropertyChanged(); } }
        #endregion

        #endregion

        #region Commands
        private RelayCommand addProjectCommand;
        public RelayCommand AddProjectCommand => addProjectCommand ?? (addProjectCommand = new RelayCommand(ShowAddProjectPage));

        private RelayCommand deleteProjectCommand;
        public RelayCommand DeleteProjectCommand => deleteProjectCommand ?? (deleteProjectCommand = new RelayCommand(DeleteProject, CanDeleteProject));

        private RelayCommand showProjectPageCommand;
        public RelayCommand ShowProjectPageCommand => showProjectPageCommand ?? (showProjectPageCommand = new RelayCommand(ShowProjectPage, CanShowProjectPage));
        #endregion

        #region Methods

        #region do commands
        private void ShowProjectPage(object obj) => MainWindowVM.ShowProjectPage(SelectedProject);
        private void ShowAddProjectPage(object obj) => MainWindowVM.ShowAddProjectPage();
        private void DeleteProject(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _project = db.projects.Find(SelectedProject.id);
                    db.projects.Remove(_project);
                    db.SaveChanges();
                    CustomMessageBox msb = new CustomMessageBox();
                    msb.ShowMessage("Проект успешно удален", "Удаление проекта", "information");
                    LoadProjects();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки данных", "error");
            }
        }
        #endregion

        #region can do commands
        private bool CanShowProjectPage(object arg)
        {
            if (SelectedProject != null)
                return true;
            return false;
        }
        private bool CanDeleteProject(object arg)
        {
            if (SelectedProject != null)
                return true;
            return false;
        }
        #endregion

        #region Load projects info
        private void LoadProjects(string value)
        {
            ProjectList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _projects = db.projects.Where(p => p.name.Contains(value)).ToList();
                    foreach (var project in _projects)
                        ProjectList.Add(project);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки данных", "error");
            }
        }
        private void LoadProjects()
        {
            ProjectList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _projects = db.projects.ToList();
                    foreach (var project in _projects)
                        ProjectList.Add(project);
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

        public ProjectsListPageViewModel(MainWindowViewModel MainWindiwVM)
        {
            this.MainWindowVM = MainWindiwVM;
            ProjectList = new ObservableCollection<project>();
            LoadProjects();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
