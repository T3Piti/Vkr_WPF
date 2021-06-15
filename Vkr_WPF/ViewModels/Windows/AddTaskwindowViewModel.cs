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

namespace Vkr_WPF.ViewModels.Windows
{
    public class AddTaskwindowViewModel : INotifyPropertyChanged
    {
        private ProjectStageWindowViewModel ProjectstageVM { get; set; }

        #region Bindings
        private string taskName;
        public string TaskName { get => taskName; set { taskName = value; OnPropertyChanged(); } }

        private string taskDescription;
        public string TaskDescription { get => taskDescription; set { taskDescription = value; OnPropertyChanged(); } }

        public ObservableCollection<task_status> StatusesList { get; set; }

        private task_status selectedStatus;
        public task_status SelectedStatus { get => selectedStatus; set { selectedStatus = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        private RelayCommand saveTaskCommand;
        public RelayCommand SaveTaskCommand => saveTaskCommand ?? (saveTaskCommand = new RelayCommand(SaveTask, CanSaveTask));
        #endregion

        #region Methods
        private void SaveTask(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    db.tasks.Add(new task {
                    name = TaskName,
                    description = TaskDescription,
                    status_id = SelectedStatus.id,
                    stage_id = ProjectstageVM.CurrentStage.id
                    });
                    db.SaveChanges();
                }
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Задание создано", "Создание задания", "information");
                ProjectstageVM.LoadTasks();
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка создания задания", "error");
            }
        }
        private bool CanSaveTask(object arg)
        {
            if (SelectedStatus != null && TaskName != String.Empty && TaskDescription != String.Empty)
                return true;
            return false;
        }

        private void LoadStatuses()
        {
            StatusesList.Clear();
            try
            {
                using (var db = new DocsdbContext())
                {
                    var _statuses = db.task_status.ToList();
                    foreach (var _status in _statuses)
                        StatusesList.Add(_status);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка загрузки статусов", "error");
            }
        }
        #endregion

        public AddTaskwindowViewModel(ProjectStageWindowViewModel vm)
        {
            ProjectstageVM = vm;
            StatusesList = new ObservableCollection<task_status>();
            LoadStatuses();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
