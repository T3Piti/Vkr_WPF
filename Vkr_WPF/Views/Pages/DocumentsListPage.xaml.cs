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
using Vkr_WPF.ViewModels.Pages;
using Vkr_WPF.Views.Windows;

namespace Vkr_WPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для DocumentsListPage.xaml
    /// </summary>
    public partial class DocumentsListPage : Page
    {
        public DocumentsListPage()
        {
            InitializeComponent();
            DocumentsListPageViewModel vm = new DocumentsListPageViewModel();
            this.DataContext = vm;
            if (vm.ShowDocumentWindowAction == null)
                vm.ShowDocumentWindowAction = new Action<Models.document>(ShowDocumentWindow);
        }

        private void ShowDocumentWindow(document obj)
        {
            DocumentWindow window = new DocumentWindow(obj);
            window.ShowDialog();
        }
    }
}
