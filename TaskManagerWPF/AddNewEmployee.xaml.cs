using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLayer;

namespace TaskManagerWPF
{
    /// <summary>
    /// Interaction logic for AddNewEmployee.xaml
    /// </summary>
    public partial class AddNewEmployee : Window
    {
        public AddNewEmployee()
        {
            InitializeComponent();
        }

        private void addEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            HideValidtion();
            bool IsValid = true;
            if (employeeNameTextBox.Text.Trim() == string.Empty)
            {
                wrongEmployeeNameLabel.Text = "Please Enter Employee Name";
                wrongEmployeeNameLabel.Visibility = Visibility.Visible;
                IsValid = false;
            }

            if (employeeEmailTextBox.Text.Trim() == string.Empty || !employeeEmailTextBox.Text.Contains("@"))
            {
                wrongEmployeeEmailLabel.Text = "Please Enter a valid Email";
                wrongEmployeeEmailLabel.Visibility = Visibility.Visible;
                IsValid = false;
            }

            int age;
            if (!int.TryParse(employeeAgeTextBox.Text, out age))
            {
                wrongEmployeeAgeLabel.Text = "Please Enter a valid Age";
                wrongEmployeeAgeLabel.Visibility = Visibility.Visible;
                IsValid = false;
            }

            int id;
            if (!int.TryParse(employeeNIDTextBox.Text, out id))
            {
                wrongEmployeeNIDLabel.Text = "Please Enter a valid NID";
                wrongEmployeeNIDLabel.Visibility = Visibility.Visible;
                IsValid = false;
            }

            if (!IsValid)
            {
                return;
            }

            Employee emp = new Employee
            {
                Name = employeeNameTextBox.Text.Trim(),
                Age = age,
                Email = employeeEmailTextBox.Text.Trim(),
                NID = id
            };

            Program.Employees.Add(emp);
            this.Close();
        }

        private void HideValidtion()
        {
            wrongEmployeeNameLabel.Visibility = Visibility.Hidden;
            wrongEmployeeNIDLabel.Visibility = Visibility.Hidden;
            wrongEmployeeAgeLabel.Visibility = Visibility.Hidden;
            wrongEmployeeEmailLabel.Visibility = Visibility.Hidden;
        }
    }
}
