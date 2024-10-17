using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace zd1_Bap1
{
    public partial class MainWindow : Window
    {
        /// <summary></summary>
        FirebaseService firebaseService = new FirebaseService();

        public MainWindow()
        {
            InitializeComponent();
            LoadEmployees();
        }

        public FirebaseService FirebaseService
        {
            get => default;
            set
            {
            }
        }

        public Employee Employee
        {
            get => default;
            set
            {
            }
        }



        // Загрузка списка сотрудников
        private async void LoadEmployees()
        {
            var employees = await firebaseService.GetEmployees();

            if (employees != null && employees.Any())
            {
                EmployeesListBox.ItemsSource = new List<Employee>(employees.Values);
            }
            else
            {
                MessageBox.Show("Список сотрудников пуст. Добавьте новых сотрудников.");
            }
        }

        // Обновление данных сотрудника
        private async void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesListBox.SelectedItem is Employee selectedEmployee)
            {
                selectedEmployee.Name = NameTextBox.Text;
                selectedEmployee.Position = PositionTextBox.Text;
                selectedEmployee.Department = DepartmentTextBox.Text;
                selectedEmployee.Age = int.Parse(AgeTextBox.Text);

                await firebaseService.UpdateEmployee(selectedEmployee);
                LoadEmployees();
            }
        }

        // Удаление сотрудника
        private async void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesListBox.SelectedItem is Employee selectedEmployee)
            {
                await firebaseService.DeleteEmployee(selectedEmployee.Id);
                LoadEmployees();
            }
        }

        // Добавление нового сотрудника
        private async void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee newEmployee = new Employee
            {
                Id = Guid.NewGuid().ToString(),
                Name = NameTextBox.Text,
                Position = PositionTextBox.Text,
                Department = DepartmentTextBox.Text,
                Age = int.Parse(AgeTextBox.Text)
            };

            await firebaseService.AddEmployee(newEmployee);
            LoadEmployees();
        }

        // Заполнение полей для редактирования выбранного сотрудника
        private void EmployeesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesListBox.SelectedItem is Employee selectedEmployee)
            {
                NameTextBox.Text = selectedEmployee.Name;
                PositionTextBox.Text = selectedEmployee.Position;
                DepartmentTextBox.Text = selectedEmployee.Department;
                AgeTextBox.Text = selectedEmployee.Age.ToString();
            }
        }

        // Очистка полей ввода
        private void ClearFields()
        {
            NameTextBox.Clear();
            PositionTextBox.Clear();
            DepartmentTextBox.Clear();
            AgeTextBox.Clear();
        }

        private void ClearFields_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            EmployeesListBox.SelectedItem = null; // Сбросить выделение в списке
        }
    }
}
