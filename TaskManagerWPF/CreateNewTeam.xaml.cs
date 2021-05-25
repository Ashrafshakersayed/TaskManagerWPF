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
    /// Interaction logic for CreateNewTeam.xaml
    /// </summary>
    public partial class CreateNewTeam : Window
    {
        TeamsList teamsList;
        public CreateNewTeam(TeamsList t)
        {
            InitializeComponent();
            teamsList = t;
            LoadEmployeeInfo();
        }

        private void LoadEmployeeInfo()
        {
            employeesListBox.Items.Clear();
            foreach (var item in Program.Employees)
            {
                employeesListBox.Items.Add(item);
            }
        }

        private void createTeamButton_Click(object sender, RoutedEventArgs e)
        {
            if (teamNameTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Team Name");
                return;
            }

            var temp = employeesListBox.SelectedItems.Count;
            if (temp == 0)
            {
                MessageBox.Show("Please Select at least one Member");
                return;
            }

            List<Employee> tempListEmp = new List<Employee>();
            foreach (var item in employeesListBox.SelectedItems)
            {
                tempListEmp.Add((Employee)item);
            }

            Team team = new Team
            {
                Name = teamNameTextBox.Text.Trim(),
                Employees = tempListEmp
            };

            Program.Teams.Add(team);
            GoToPrevPage();
        }

        private void GoToPrevPage()
        {
            teamsList.Show();
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            GoToPrevPage();
        }

        private void addNewEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmployee addNewEmployee = new AddNewEmployee();
            addNewEmployee.ShowDialog();
            LoadEmployeeInfo();
        }
    }
}
