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
using Vkr_WPF.ViewModels.Windows;

namespace Vkr_WPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            AuthorizationWindowViewModel vm = new AuthorizationWindowViewModel();
            this.DataContext = vm;
            if (vm.CloseCurrentWindowAction == null)
                vm.CloseCurrentWindowAction = new Action(this.Close);
            if (vm.ShowMainWindowAction == null)
                vm.ShowMainWindowAction = new Action<Models.user>(ShowMainWindow);

        }

        private void ShowMainWindow(user obj)
        {
            MainWindow window = new MainWindow(obj);
            window.Show();
        }
    }
}
