using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Vkr_WPF.Models;
using Vkr_WPF.Models.CustomDataModels;
using Vkr_WPF.ViewModels.Windows;

namespace Vkr_WPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProjectStageWindow.xaml
    /// </summary>
    public partial class ProjectStageWindow : Window
    {
        public ProjectStageWindow(stage obj)
        {
            InitializeComponent();
            ProjectStageWindowViewModel vm = new ProjectStageWindowViewModel(obj);
            this.DataContext = vm;
            if (vm.ShowEmployeeWindowAction == null)
                vm.ShowEmployeeWindowAction = new Action<Models.CustomDataModels.ShortEmployeeModel>(ShowEmployeeWindow);
            if (vm.ShowTaskWindowAction == null)
                vm.ShowTaskWindowAction = new Action<ProjectStageWindowViewModel>(ShowTaskWindow);
            if (vm.ShowDocumentWindowAction == null)
                vm.ShowDocumentWindowAction = new Action<document>(ShowDocumentWindow);
            if (vm.ShowAddTaskWindowAction == null)
                vm.ShowAddTaskWindowAction = new Action<ProjectStageWindowViewModel>(ShowAddTaskWindow);
            if (vm.ShowAddDocumentWindowAction == null)
                vm.ShowAddDocumentWindowAction = new Action<ProjectStageWindowViewModel>(ShowAddDocumentWindow);
        }

        private void ShowAddDocumentWindow(ProjectStageWindowViewModel obj)
        {
            AddDocumentWindow window = new AddDocumentWindow(obj);
            window.ShowDialog();
        }

        private void ShowAddTaskWindow(ProjectStageWindowViewModel obj)
        {
            AddTaskwindow window = new AddTaskwindow(obj);
            window.ShowDialog();
        }

        private void ShowDocumentWindow(document obj)
        {
            DocumentWindow window = new DocumentWindow(obj);
            window.ShowDialog();
        }

        private void ShowTaskWindow(ProjectStageWindowViewModel obj)
        {
            TaskWindow window = new TaskWindow(obj);
            window.ShowDialog();
        }

        private void ShowEmployeeWindow(ShortEmployeeModel obj)
        {
            EmployeeWindow window = new EmployeeWindow(obj);
            window.ShowDialog();
        }
    }
}
