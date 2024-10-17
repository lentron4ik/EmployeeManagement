using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace zd1_Bap1
{
    public class FirebaseService
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "/employeemanagement-c2381-firebase-adminsdk-33n9u-ab1ab3417b",
            BasePath = "https://employeemanagement-c2381-default-rtdb.firebaseio.com"
        };

        IFirebaseClient client;

        public FirebaseService()
        {
            client = new FireSharp.FirebaseClient(config);
        }

        public Employee Employee
        {
            get => default;
            set
            {
            }
        }

        // Добавление сотрудника
        public async Task AddEmployee(Employee employee)
        {
            SetResponse response = await client.SetAsync("Employees/" + employee.Id, employee);
        }

        // Получение всех сотрудников
        public async Task<Dictionary<string, Employee>> GetEmployees()
        {
            FirebaseResponse response = await client.GetAsync("Employees");
            return response.ResultAs<Dictionary<string, Employee>>();
        }

        // Обновление данных сотрудника
        public async Task UpdateEmployee(Employee employee)
        {
            SetResponse response = await client.SetAsync("Employees/" + employee.Id, employee);
        }

        // Удаление сотрудника
        public async Task DeleteEmployee(string employeeId)
        {
            FirebaseResponse response = await client.DeleteAsync("Employees/" + employeeId);
        }
    }
}
