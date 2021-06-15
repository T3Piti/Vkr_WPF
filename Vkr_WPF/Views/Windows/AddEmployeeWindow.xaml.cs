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
using Vkr_WPF.ViewModels.Pages;
using Vkr_WPF.ViewModels.Windows;

namespace Vkr_WPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow(ProjectPageViewModel obj)
        {
            InitializeComponent();
            AddEmployeeWindowViewModel vm = new AddEmployeeWindowViewModel(obj);
            this.DataContext = vm;
        }

        public AddEmployeeWindow(TaskWindowViewModel obj)
        {
            InitializeComponent();
            AddEmployeeWindowViewModel vm = new AddEmployeeWindowViewModel(obj);
            this.DataContext = vm;
        }
    }
}
