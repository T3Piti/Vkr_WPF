using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Vkr_WPF.Models;
using Vkr_WPF.RelayCommands;
using Vkr_WPF.Views.Pages;

namespace Vkr_WPF.ViewModels.Windows
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private users_info CurrentUser { get; set; }

        #region Actions
        public Action CloseWindowAction { get; set; }
        #endregion

        #region Bindings

        #region User info
        private string userName;
        public string UserName { get => userName; set { userName = value; OnPropertyChanged(); } }
        #endregion

        #region Page info
        private Page currentPage;
        public Page CurrentPage { get => currentPage; set { currentPage = value; OnPropertyChanged(); } }

        private string pageName;
        public string PageName { get => pageName; set { pageName = value; OnPropertyChanged(); } }
        #endregion

        #endregion

        #region Commands
        private RelayCommand showProjectsListPageCommand;
        public RelayCommand ShowProjectsListPageCommand => showProjectsListPageCommand ?? (showProjectsListPageCommand = new RelayCommand(ShowProjectsListPage));

        private RelayCommand showDocumentsListPageCommand;
        public RelayCommand ShowDocumentsListPageCommand => showDocumentsListPageCommand ?? (showDocumentsListPageCommand = new RelayCommand(ShowDocumentsListPage));

        private RelayCommand showRegistrationPageCommand;
        public RelayCommand ShowRegistrationPageCommand => showRegistrationPageCommand ?? (showRegistrationPageCommand = new RelayCommand(ShowRegistrationPage));

        private RelayCommand closeWindowCommand;
        public RelayCommand CloseWindowCommand => closeWindowCommand ?? (closeWindowCommand = new RelayCommand(CloseWindow));
        #endregion

        #region Commands methods
        private void ShowRegistrationPage(object obj)
        {
            PageName = "Регистрация";
            CurrentPage = new RegistrationPage();
        }
        private void ShowDocumentsListPage(object obj)
        {
            PageName = "Документы";
            CurrentPage = new DocumentsListPage();
        }
        private void ShowProjectsListPage(object obj)
        {
            PageName = "Проекты";
            CurrentPage = new ProjectsListPage(this);
        }
        public void ShowProjectPage(project _project )
        {
            PageName = "Проект";
            CurrentPage = new ProjectPage(_project);
        }
        public void ShowAddProjectPage()
        {
            PageName = "Добавление проекта";
            CurrentPage = new AddProjectPage();
        }
        private void CloseWindow(object obj) => CloseWindowAction();
        #endregion

        public MainWindowViewModel(user currentUser)
        {
            CurrentUser = currentUser.users_info.FirstOrDefault();
            UserName = CurrentUser.name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
