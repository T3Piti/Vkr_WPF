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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vkr_WPF.Models;
using Vkr_WPF.Models.CustomDataModels;
using Vkr_WPF.ViewModels.Pages;
using Vkr_WPF.Views.Windows;

namespace Vkr_WPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        public ProjectPage(project obj)
        {
            InitializeComponent();
            ProjectPageViewModel vm = new ProjectPageViewModel(obj);
            this.DataContext = vm;
            if (vm.ShowEmployeeWindowAction == null)
                vm.ShowEmployeeWindowAction = new Action<Models.CustomDataModels.ShortEmployeeModel>(ShowEmployeeWindow);
            if (vm.ShowDocumentWindowAction == null)
                vm.ShowDocumentWindowAction = new Action<document>(ShowDocumentWindow);
            if (vm.ShowProjectStageWindowAction == null)
                vm.ShowProjectStageWindowAction = new Action<stage>(ShowProjectStageWindow);
            if (vm.ShowAddStageWindowAction == null)
                vm.ShowAddStageWindowAction = new Action<ProjectPageViewModel>(ShowAddStageWindow);
            if (vm.ShowAddDocumentWindowAction == null)
                vm.ShowAddDocumentWindowAction = new Action<ProjectPageViewModel>(ShowAddDocumentWindow);
            if (vm.ShowAddEmployeeWindowAction == null)
                vm.ShowAddEmployeeWindowAction = new Action<ProjectPageViewModel>(ShowAddEmployeeWindow);
        }

        private void ShowAddEmployeeWindow(ProjectPageViewModel obj)
        {
            AddEmployeeWindow window = new AddEmployeeWindow(obj);
            window.ShowDialog();
        }

        private void ShowAddDocumentWindow(ProjectPageViewModel obj)
        {
            AddDocumentWindow window = new AddDocumentWindow(obj);
            window.ShowDialog();
        }

        private void ShowAddStageWindow(ProjectPageViewModel obj)
        {
            AddStageWindow window = new AddStageWindow(obj);
            window.ShowDialog();
        }

        private void ShowProjectStageWindow(stage obj)
        {
            ProjectStageWindow window = new ProjectStageWindow(obj);
            window.ShowDialog();
        }

        private void ShowEmployeeWindow(ShortEmployeeModel obj)
        {
            EmployeeWindow window = new EmployeeWindow(obj);
            window.ShowDialog();
        }

        private void ShowDocumentWindow(document obj)
        {
            DocumentWindow window = new DocumentWindow(obj);
            window.ShowDialog();
        }
    }
}
