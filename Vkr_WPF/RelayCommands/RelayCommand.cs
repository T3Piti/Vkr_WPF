using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vkr_WPF.Models;
using Vkr_WPF.ViewModels.Pages;

namespace Vkr_WPF.RelayCommands
{
    public class RelayCommand : ICommand
    {
        private Action<document> showDocumentWindow;
        private object canShowDocumentWindow;
        private Action<ProjectPageViewModel> showAddStageWindow;
        private RelayCommand showAddDocumentWindow;

        private Action<object> execute { get; set; }
        private Func<object, bool> canExecute { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<document> showDocumentWindow, object canShowDocumentWindow)
        {
            this.showDocumentWindow = showDocumentWindow;
            this.canShowDocumentWindow = canShowDocumentWindow;
        }

        public RelayCommand(Action<ProjectPageViewModel> showAddStageWindow)
        {
            this.showAddStageWindow = showAddStageWindow;
        }

        public RelayCommand(RelayCommand showAddDocumentWindow)
        {
            this.showAddDocumentWindow = showAddDocumentWindow;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
