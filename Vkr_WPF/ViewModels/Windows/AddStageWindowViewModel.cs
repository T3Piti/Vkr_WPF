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
using Vkr_WPF.ViewModels.Pages;

namespace Vkr_WPF.ViewModels.Windows
{
    public class AddStageWindowViewModel : INotifyPropertyChanged
    {
        private ProjectPageViewModel CurrentProject;

        #region Bindings
        private string stageName;
        public string StageName { get => stageName; set { stageName = value; OnPropertyChanged(); } }

        public ObservableCollection<task_status> StatusesList { get; set; }

        private task_status selectedStatus;
        public task_status SelectedStatus { get => selectedStatus; set { selectedStatus = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        private RelayCommand addStageCommand;
        public RelayCommand AddStageCommand => addStageCommand ?? (addStageCommand = new RelayCommand(AddStage, CanAddStage));
        #endregion

        #region Methods

        #region do commands
        private void AddStage(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    db.stages.Add(new stage { 
                    name = StageName,
                    status_id = SelectedStatus.id,
                    project_id = CurrentProject.CurrentProject.id
                    });
                    db.SaveChanges();
                }
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Этап добавлен", "Добавления этапа", "information");
                CurrentProject.LoadStages();
            }
            catch(Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка добавления этапа", "error");
            }
        }
        #endregion

        #region can do commands
        private bool CanAddStage(object arg)
        {
            if (SelectedStatus != null)
                return true;
            return false;
        }
        #endregion

        #region load
        private void LoadStatuses()
        {
            StatusesList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var statuses = db.task_status.ToList();
                    foreach (var status in statuses)
                        StatusesList.Add(status);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки информации", "error");
            }
        }
        #endregion

        #endregion

        public AddStageWindowViewModel(ProjectPageViewModel _project)
        {
            CurrentProject = _project;
            StatusesList = new ObservableCollection<task_status>();
            LoadStatuses();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
