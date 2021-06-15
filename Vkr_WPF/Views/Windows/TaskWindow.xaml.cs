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
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        public TaskWindow(ProjectStageWindowViewModel obj)
        {
            InitializeComponent();
            TaskWindowViewModel vm = new TaskWindowViewModel(obj);
            this.DataContext = vm;
            if (vm.ShowAddEmployeeWindowAction == null)
                vm.ShowAddEmployeeWindowAction = new Action<TaskWindowViewModel>(ShowAddEmployeeWindow);
            if (vm.ShowEmployeeWindowAction == null)
                vm.ShowEmployeeWindowAction = new Action<Models.CustomDataModels.ShortEmployeeModel>(ShowEmployeeWindow);
        }

        private void ShowEmployeeWindow(ShortEmployeeModel obj)
        {
            EmployeeWindow window = new EmployeeWindow(obj);
            window.ShowDialog();
        }

        private void ShowAddEmployeeWindow(TaskWindowViewModel obj)
        {
            AddEmployeeWindow window = new AddEmployeeWindow(obj);
            window.ShowDialog();
        }
    }
}
