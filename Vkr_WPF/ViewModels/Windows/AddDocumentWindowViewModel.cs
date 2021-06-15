using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using Vkr_WPF.CustomFileDialog;
using Vkr_WPF.CustomMessages;
using Vkr_WPF.Models;
using Vkr_WPF.RelayCommands;
using Vkr_WPF.UserInfoStatic;
using Vkr_WPF.ViewModels.Pages;

namespace Vkr_WPF.ViewModels.Windows
{
    public class AddDocumentWindowViewModel : INotifyPropertyChanged
    {
        private ProjectPageViewModel ProjectPageVM { get; set; }
        private ProjectStageWindowViewModel ProjectStageVM { get; set; }

        #region Bindings
        private IDocumentPaginatorSource docText;
        public IDocumentPaginatorSource DocText { get => docText; set { docText = value; OnPropertyChanged(); } }

        private string fileName;
        public string FileName { get => fileName; set { fileName = value; OnPropertyChanged(); } }

        private string FilePath;

        public ObservableCollection<documents_status> StatusesList { get; set; }

        private documents_status selectedStatus;
        public documents_status SelectedStatus { get => selectedStatus; set { selectedStatus = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        private RelayCommand chooseFileCommand;
        public RelayCommand ChooseFileCommand => chooseFileCommand ?? (chooseFileCommand = new RelayCommand(ChooseFile));

        private RelayCommand addDocumentCommand;
        public RelayCommand AddDocumentCommand => addDocumentCommand ?? (addDocumentCommand = new RelayCommand(AddDocument, CanAddDocument));
        #endregion

        #region Methods

        private void LoadStatuses()
        {
            StatusesList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _statuses = db.documents_status.ToList();
                    foreach (var _status in _statuses)
                        StatusesList.Add(_status);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Загрузки статусов", "error");
            }
        }

        #region do commands
        private void ChooseFile(object obj)
        {
            DocxFileDialog fdl = new DocxFileDialog();
            FileName = fdl.FileChooser(ref docText, ref FilePath);
            if (!String.IsNullOrEmpty(FileName))
                DocText = docText;
        }
        private void AddDocument(object obj)
        {
            DocxFileDialog fd = new DocxFileDialog();
            //try
            //{
                if (this.ProjectPageVM != null)
                {
                    AddDocumentToProject(fd);
                    this.ProjectPageVM.LoadDocuments();
                }
                else
                {
                    AddDocumentToStage(fd);
                    this.ProjectStageVM.LoadDocuments();
                }
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Документ добавлен", "Добавление документа", "information");
            //}
            //catch (Exception ex)
            //{
                //CustomMessageBox msb = new CustomMessageBox();
                //msb.ShowMessage(ex.Message, "Ошибка добавления документа", "error");
            //}
        }

        private void AddDocumentToStage(DocxFileDialog fd)
        {
            var _document = new document
            {
                name = FileName,
                date = DateTime.Now,
                document_file = fd.ConvertToByte(FilePath),
                user_info_id = UserData.User.id,
                status_id = SelectedStatus.id

            };
            using (var db = new DocsdbContext())
            {
                db.documents.Add(_document);
                db.project_has_document.Add(new project_has_document
                {
                    project_id = ProjectStageVM.CurrentStage.project_id,
                    document_id =_document.id,
                    stage_id = ProjectStageVM.CurrentStage.id
                });
                db.SaveChanges();
            }
        }

        private void AddDocumentToProject(DocxFileDialog fd)
        {
            var _document = new document
            {
                name = FileName,
                date = DateTime.Now,
                document_file = fd.ConvertToByte(FilePath),
                user_info_id = UserData.User.id,
                status_id = SelectedStatus.id

            };
            using (var db = new DocsdbContext())
            {
                db.documents.Add(_document);
                db.SaveChanges();
                db.project_has_document.Add(new project_has_document
                {
                    project_id = ProjectPageVM.CurrentProject.id,
                    document_id = _document.id                    
                });
                db.SaveChanges();
            }
        }
        #endregion

        #region can do commands
        private bool CanAddDocument(object arg)
        {
            if (DocText != null && SelectedStatus!=null)
                return true;
            return false;
        }
        #endregion

        #endregion

        #region Costructors
        public AddDocumentWindowViewModel(ProjectPageViewModel vm)
        {
            StatusesList = new ObservableCollection<documents_status>();
            this.ProjectPageVM = vm;
            LoadStatuses();

        }
        public AddDocumentWindowViewModel(ProjectStageWindowViewModel vm)
        {
            StatusesList = new ObservableCollection<documents_status>();
            this.ProjectStageVM = vm;
            LoadStatuses();
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
