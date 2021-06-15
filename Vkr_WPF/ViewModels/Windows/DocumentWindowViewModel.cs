using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Vkr_WPF.CustomFileDialog;
using Vkr_WPF.Models;
using Vkr_WPF.RelayCommands;

namespace Vkr_WPF.ViewModels.Windows
{
    public class DocumentWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> EditsList { get; set; }
        
        private string path;

        private string selectedEdit;
        public string SelectedEdit { get => selectedEdit; set { selectedEdit = value; OnPropertyChanged(); } }

        public ObservableCollection<documents_status> StatusesList { get; set; }

        private documents_status selectedStatus;
        public documents_status SelectedStatus { get => selectedStatus; set { selectedStatus = value; OnPropertyChanged(); } }

        private IDocumentPaginatorSource docText;
        public IDocumentPaginatorSource DocText { get => docText; set { docText = value; OnPropertyChanged(); } }

        private RelayCommand showDescriptionCommand;
        public RelayCommand ShowDescriptionCommand => showDescriptionCommand ?? (showDescriptionCommand = new RelayCommand(ShowDescription, CanShowDescription));
        private void ShowDescription(object obj)
        {
            MessageBox.Show("Ковалев Максим Кириллович\nТестовая правка", "Описание правки", MessageBoxButton.OK);
        }
        private bool CanShowDescription(object arg)
        {
            if (SelectedEdit != String.Empty)
                return true;
            return false;
        }

        private RelayCommand removeEditCommand;
        public RelayCommand RemoveEditCommand => removeEditCommand ?? (removeEditCommand = new RelayCommand(RemoveEdit, CanRemoveEdit));
        private void RemoveEdit(object obj)
        {
            EditsList.Clear();
            MessageBox.Show("Правка убрана", "Отмена правки", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private bool CanRemoveEdit(object arg)
        {
            if (SelectedEdit != null)
                return true;
            return false;
        }

        private RelayCommand downloadCommand;
        public RelayCommand DownloadCommand => downloadCommand ?? (downloadCommand = new RelayCommand(Download));

        private void Download(object obj)
        {
            DocxFileDialog fd = new DocxFileDialog();
            fd.FileChooser();
        }

        public DocumentWindowViewModel(document obj)
        {
            EditsList = new ObservableCollection<string>();
            DocxFileDialog fd = new DocxFileDialog();
            fd.FileChooser(ref docText, ref path);
        }

        public DocumentWindowViewModel()
        {
            DocxFileDialog fd = new DocxFileDialog();
            DocText = fd.OpenFile(@"C:\Users\ККК\Desktop\Учеба\дип (1).docx");
            EditsList = new ObservableCollection<string>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
