using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Vkr_WPF.Models;
using Vkr_WPF.RelayCommands;

namespace Vkr_WPF.ViewModels.Windows
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private users_info CurrentUser { get; set; }

        #region Actions
        public Action<MainWindowViewModel> ShowProjectsListPageAction { get; set; }
        public Action ShowDocumentsListPageAction { get; set; }
        public Action ShowRegistrationPageAction { get; set; }
        public Action<project> ShowProjectPageAction { get; set; }
        public Action ShowAddProjectPageAction { get; set; }
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
        #endregion

        #region Commands methods
        private void ShowRegistrationPage(object obj)
        {
            PageName = "Регистрация";
            ShowRegistrationPageAction();
        }
        private void ShowDocumentsListPage(object obj)
        {
            PageName = "Документы";
            ShowDocumentsListPageAction();
        }
        private void ShowProjectsListPage(object obj)
        {
            PageName = "Проекты";
            ShowProjectsListPageAction(this);
        }
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
