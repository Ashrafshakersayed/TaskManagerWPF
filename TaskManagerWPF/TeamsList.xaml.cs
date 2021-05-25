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
    /// Interaction logic for TeamsList.xaml
    /// </summary>
    public partial class TeamsList : Window
    {
        public TeamsList()
        {
            InitializeComponent();
            LoadTeams();
        }

        private void LoadTeams()
        {
            teamsListBox.Items.Clear();
            foreach (Team team in BusinessLayer.Program.Teams)
            {
                teamsListBox.Items.Add(team);
            }
        }

        private void createTeamButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewTeam createNewTeam = new CreateNewTeam(this);
            createNewTeam.ShowDialog();
            LoadTeams();
        }

        private void teamsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*if (teamsListBox.SelectedIndex == -1)
                return;

            TeamDetailsFrm teamDetails = new TeamDetailsFrm((Team)teamsListBox.SelectedItem);
            this.Hide();
            teamDetails.ShowDialog();
            this.Show();
            LoadTeams();*/
        }

        private void addEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmployee addNewEmployee = new AddNewEmployee();
            addNewEmployee.ShowDialog();
        }

        private void deleteTeamButton_Click(object sender, RoutedEventArgs e)
        {
            if (teamsListBox.SelectedIndex == -1)
                return;
            Program.Teams.Remove((Team)teamsListBox.SelectedItem);
            teamsListBox.Items.RemoveAt(teamsListBox.SelectedIndex);
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (teamsListBox.SelectedIndex == -1)
                return;
            TeamDetailsFrm teamDetails = new TeamDetailsFrm((Team)teamsListBox.SelectedItem);
            this.Hide();
            teamDetails.ShowDialog();
            this.Show();
            LoadTeams();
        }
    }
}
