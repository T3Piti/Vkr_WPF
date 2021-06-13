using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using Vkr_WPF.CustomFileDialog;
using Vkr_WPF.CustomMessages;
using Vkr_WPF.Models;
using Vkr_WPF.RelayCommands;
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

        public ObservableCollection<project> ProjectsList { get; set; }
        public ObservableCollection<stage> StagesList { get; set; }

        private project selectedDocumentProject;
        public project SelectedDocumentProject { get => selectedDocumentProject; set { selectedDocumentProject = value; OnPropertyChanged(); } }

        private stage selectedProjectStage;
        public stage SelectedProjectStage { get=> selectedProjectStage; set { selectedProjectStage = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        private RelayCommand chooseFileCommand;
        public RelayCommand ChooseFileCommand => chooseFileCommand ?? (chooseFileCommand = new RelayCommand(ChooseFile));

        private RelayCommand addDocumentCommand;
        public RelayCommand AddDocumentCommand => addDocumentCommand ?? (addDocumentCommand = new RelayCommand(AddDocument, CanAddDocument));
        #endregion

        #region Methods

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
            try
            {
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
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка добавления документа", "error");
            }
        }

        private void AddDocumentToStage(DocxFileDialog fd)
        {
            using (var db = new DocsdbContext())
            {
                db.documents.Add(new document
                {
                    name = FileName,
                    date = DateTime.Now,
                    document_file = fd.ConvertToByte(FilePath)
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
                document_file = fd.ConvertToByte(FilePath)

            };
            using (var db = new DocsdbContext())
            {
                db.documents.Add(_document);
                db.SaveChanges();
                db.project_has_document.Add(new project_has_document
                {
                    project_id = ProjectPageVM.CurrentProject.id,
                    document_id = _document.id,
                });
                db.SaveChanges();
            }
        }
        #endregion

        #region can do commands
        private bool CanAddDocument(object arg)
        {
            if (DocText != null)
                return true;
            return false;
        }
        #endregion

        #endregion

        #region Costructors
        public AddDocumentWindowViewModel(ProjectPageViewModel vm) => this.ProjectPageVM = vm;
        public AddDocumentWindowViewModel(ProjectStageWindowViewModel vm) => this.ProjectStageVM = vm;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
