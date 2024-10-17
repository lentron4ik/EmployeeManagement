using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1_Bap1
{
    public class Employee
    {
        public string Id { get; set; } // Уникальный идентификатор сотрудника
        public string Name { get; set; } // Имя сотрудника
        public string Position { get; set; } // Должность
        public string Department { get; set; } // Отдел
        public int Age { get; set; } // Возраст
    }
}
