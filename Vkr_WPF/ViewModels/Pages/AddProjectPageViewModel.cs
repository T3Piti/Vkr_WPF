using System;
using System.Collections.Generic;
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
    public class AddProjectPageViewModel : INotifyPropertyChanged
    {
        #region Bindings
        private string projectName;
        public string ProjectName { get => projectName; set { projectName = value; OnPropertyChanged(); } }

        private DateTime dateStart;
        public DateTime DateStart { get => dateStart; set { dateStart = value; OnPropertyChanged(); } }

        private DateTime dateEnd;
        public DateTime DateEnd { get => dateEnd; set { dateEnd = value; OnPropertyChanged(); } }
        #endregion


        #region Commands
        private RelayCommand addProjectCommand;
        public RelayCommand AddProjectCommand => addProjectCommand ?? (addProjectCommand = new RelayCommand(AddProject, CanAddProject));
        #endregion

        #region Methods

        #region do commands
        private void AddProject(object obj)
        {
            try
            {
                using (var db = new DocsdbContext())
                {
                    db.projects.Add(new project { 
                    name = ProjectName,
                    date_start = DateStart,
                    date_end = DateEnd
                    });
                    db.SaveChanges();
                }
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage("Проект успешно создан", "Создание проекта", "information");
            }
            catch (Exception ex)
            {
                CustomMessageBox msb = new CustomMessageBox();
                msb.ShowMessage(ex.Message, "Ошибка создания проекта", "error");
            }
        }
        #endregion

        #region can do commands
        private bool CanAddProject(object arg)
        {
            if (DateStart > DateEnd)
                return true;
            return false;
        }
        #endregion

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
