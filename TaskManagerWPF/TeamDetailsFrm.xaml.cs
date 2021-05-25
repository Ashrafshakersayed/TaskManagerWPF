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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer;

namespace TaskManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TeamDetailsFrm : Window
    {
        public Team SelectedTeam { get; set; }

        public TeamDetailsFrm(Team selectedTeam)
        {
            InitializeComponent();
            SelectedTeam = selectedTeam;
            ShowTasks();
            
        }

        private void ShowTasks()
        {
            dgvTasks.ItemsSource = null;
            dgvTasks.ItemsSource = SelectedTeam.Tasks;
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            CreateCategoryFrm createCategory = new CreateCategoryFrm(this);
            createCategory.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            createCategory.ShowDialog();
        }

        private void BtnShowEmployees_Click(object sender, RoutedEventArgs e)
        {
            EditEmployeeFrm editEmployeeFrm = new EditEmployeeFrm(SelectedTeam.Employees, Program.Employees, ComeFrom.TeamForm, SelectedTeam.Tasks);
            editEmployeeFrm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editEmployeeFrm.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(dgvTasks.SelectedIndex >= 0)
            {
                TaskDetailsFrm task = new TaskDetailsFrm(SelectedTeam, SelectedTeam.Tasks[dgvTasks.SelectedIndex]);
                task.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                task.ShowDialog();
                ShowTasks();
            }
        }

        private void dgvTasks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgvTasks.SelectedIndex >= 0)
            {
                TaskDetailsFrm task = new TaskDetailsFrm(SelectedTeam, SelectedTeam.Tasks[dgvTasks.SelectedIndex]);
                task.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                task.ShowDialog();
                ShowTasks();
            }
        }

        private void btnAddNewTask_Click(object sender, RoutedEventArgs e)
        {
            CreateNewTaskFrm createNewTaskFrm = new CreateNewTaskFrm(this);
            createNewTaskFrm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            createNewTaskFrm.ShowDialog();
            ShowTasks();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgvTasks.SelectedIndex >= 0)
            {
                SelectedTeam.Tasks.RemoveAt(dgvTasks.SelectedIndex);
                ShowTasks();
            }
        }
    }
}
