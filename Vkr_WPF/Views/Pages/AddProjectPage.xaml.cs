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
using Vkr_WPF.ViewModels.Pages;

namespace Vkr_WPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProjectPage.xaml
    /// </summary>
    public partial class AddProjectPage : Page
    {
        public AddProjectPage()
        {
            InitializeComponent();
            AddProjectPageViewModel vm = new AddProjectPageViewModel();
            this.DataContext = vm;
        }
    }
}
