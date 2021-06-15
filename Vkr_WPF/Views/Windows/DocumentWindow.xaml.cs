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
    /// Логика взаимодействия для DocumentWindow.xaml
    /// </summary>
    public partial class DocumentWindow : Window
    {
        public DocumentWindow(document obj)
        {
            InitializeComponent();
            DocumentWindowViewModel vm = new DocumentWindowViewModel(obj);
            this.DataContext = vm;
        }

        public DocumentWindow()
        {
            InitializeComponent();
            DocumentWindowViewModel vm = new DocumentWindowViewModel();
            this.DataContext = vm;
        }
    }
}
