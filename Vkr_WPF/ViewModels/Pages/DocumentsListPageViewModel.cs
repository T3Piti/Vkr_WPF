using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vkr_WPF.CustomMessages;
using Vkr_WPF.Models;
using Vkr_WPF.RelayCommands;

namespace Vkr_WPF.ViewModels.Pages
{
    public class DocumentsListPageViewModel : INotifyPropertyChanged
    {
        #region Actions
        public Action<document> ShowDocumentWindowAction { get; set; }
        public Action<DocumentsListPageViewModel> ShowAddDocumentWindowAction { get;set; }
        #endregion

        #region Bindings

        private string searchDocument;
        public string SearchDocument { get => searchDocument;
            set {
                searchDocument = value;
                if (value != String.Empty)
                    LoadDocuments(value);
                else
                    LoadDocuments();
                OnPropertyChanged();
            }
        }

        #region collections
        public ObservableCollection<document> DocumentsList { get; set; }
        #endregion

        #region selected items
        private document selectedDocument;
        public document SelectedDocument { get => selectedDocument; set { selectedDocument = value; OnPropertyChanged(); } }
        #endregion

        #endregion

        public DocumentsListPageViewModel()
        {
            DocumentsList = new ObservableCollection<document>();
            LoadDocuments();
        }

        #region Commands
        private RelayCommand deleteDocumentCommand;
        public RelayCommand DeleteDocumentCommand => deleteDocumentCommand ?? (deleteDocumentCommand = new RelayCommand(DeleteDocument, CanDeleteDocument));

        private RelayCommand showDocumentWindowCommand;
        public RelayCommand ShowDocumentWindowCommand => showDocumentWindowCommand ?? (showDocumentWindowCommand = new RelayCommand(ShowDocumentWindow, CanShowDocumentWindow));

        private RelayCommand showAddDocumentWindowCommand;
        public RelayCommand ShowAddDocumentWindowCommand => showAddDocumentWindowCommand ?? (showAddDocumentWindowCommand = new RelayCommand(ShowAddDocumentWindow));
        #endregion

        #region Methods

        #region do commands
        private void ShowDocumentWindow(object obj) => ShowDocumentWindowAction(SelectedDocument);
        private void DeleteDocument(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _document = db.documents.Find(SelectedDocument.id);
                    db.documents.Remove(_document);
                    db.SaveChanges();
                }

                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Документ удален", "Удаление документа", "information");
                LoadDocuments();

            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка удаления документа", "error");
            }
        }
        private void ShowAddDocumentWindow(object obj) => ShowAddDocumentWindowAction(this);
        #endregion

        #region can do commands
        private bool CanShowDocumentWindow(object arg)
        {
            if (SelectedDocument != null)
                return true;
            return false;
        }
        private bool CanDeleteDocument(object arg)
        {
            if (SelectedDocument != null)
                return true;
            return false;
        }
        #endregion

        #region load
        public void LoadDocuments()
        {
            DocumentsList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _documents = db.documents.ToList();
                    foreach (var document in _documents)
                        DocumentsList.Add(document);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки документов", "error");
            }
        }
        private void LoadDocuments(string search)
        {
            DocumentsList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _documents = db.documents.Where(d=> d.name.Contains(search)).ToList();
                    foreach (var document in _documents)
                        DocumentsList.Add(document);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки документов", "error");
            }
        }
        #endregion

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
