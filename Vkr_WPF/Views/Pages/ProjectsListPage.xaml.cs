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
using Vkr_WPF.ViewModels.Windows;

namespace Vkr_WPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProjectsListPage.xaml
    /// </summary>
    public partial class ProjectsListPage : Page
    {
        public ProjectsListPage(MainWindowViewModel obj)
        {
            InitializeComponent();
            ProjectsListPageViewModel vm = new ProjectsListPageViewModel(obj);
            this.DataContext = vm;
        }
    }
}
