using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vkr_WPF.Models.CustomDataModels
{
    public class ShortEmployeeModel
    {
        private string name;
        private string secondName;
        private string patronymic;
        private string department;
        private int id;
        private int departmentId;

        public string Name { get => name; set => name = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string Patronymic { get => patronymic; set => patronymic = value; }
        public string Department { get => department; set => department = value; }
        public int Id { get => id; set => id = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }
    }
}
