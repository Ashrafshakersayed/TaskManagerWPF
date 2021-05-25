using Microsoft.Win32;
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
    /// Interaction logic for CreateNewTaskFrm.xaml
    /// </summary>
    public partial class CreateNewTaskFrm : Window
    {
        TeamDetailsFrm previousWin { get; set; }
        Team team { get; set; }
        public CreateNewTaskFrm(TeamDetailsFrm previousWin)
        {
            InitializeComponent();
            this.previousWin = previousWin;
            team = previousWin.SelectedTeam;

            cbPriority.ItemsSource = new List<TaskPriority> {
                TaskPriority.High,
                TaskPriority.Medium,
                TaskPriority.Low
            };

            foreach (Employee employee in team.Employees)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = employee.Name;
                checkBox.Tag = employee;
                checkBox.Checked += UpdateSlectedEmployers;
                checkBox.Unchecked += DeleteSlectedEmployees;
                cbEmployees.Items.Add(checkBox);
            }
            loadCategories();

            deadlinePicker.DisplayDateStart = DateTime.Now;
            deadlinePicker.SelectedDate = DateTime.Now;
        }

        private void DeleteSlectedEmployees(object sender, RoutedEventArgs e)
        {
            string EmployeeName = ((CheckBox)sender).Content.ToString();
            SelectedEmployeesNames.Text =
                SelectedEmployeesNames.Text.Replace($"{EmployeeName} , ", "");
        }

        private void UpdateSlectedEmployers(object sender, RoutedEventArgs e)
        {
            string EmployeeName = ((CheckBox)sender).Content.ToString();
            SelectedEmployeesNames.Text += $"{EmployeeName} , ";

        }

        private void loadCategories()
        {
            cbCategory.ItemsSource = null;
            cbCategory.ItemsSource = team.Categories;
        }
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (txtTaskName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Task name can not be Empty", "Name error",
                 MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (cbCategory.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Task Category can not be Empty", "Category error",
                 MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            BusinessLayer.Task task = new BusinessLayer.Task();
            task.Name = txtTaskName.Text;
            task.Priority = (TaskPriority)cbPriority.SelectedItem;
            task.Deadline = deadlinePicker.SelectedDate.Value;
            foreach (CheckBox item in cbEmployees.Items)
            {
                if ((bool)item.IsChecked)
                    task.Employees.Add((Employee)item.Tag);
            }

            task.Category = cbCategory.Text;
            foreach (string item in filesListView.Items)
            {
                task.Files.Add(item);
            }

            foreach (CheckBox item in SubtaskListView.Items)
            {
                SubTask subtask = new SubTask(item.Content.ToString());
                subtask.CheckSubTask = (bool)item.IsChecked;
                task.SubTasks.Add(subtask);
            }

            task.Comments = new List<string>();

            team.Tasks.Add(task);
            //    previousFrm.Show();
            Close();
        }

        private void btnAddSubtask_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Content = txtSubtask.Text;
            SubtaskListView.Items.Add(checkBox);
            txtSubtask.Clear();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF |*.pdf|doc|*.doc;*.docx|Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if ((bool)fileDialog.ShowDialog())
            {
                filesListView.Items.Add(fileDialog.FileName);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtSubtask_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnAddSubtask.IsEnabled = !(txtSubtask.Text.Trim() == string.Empty);
        }

        private void btnAddCat_Click(object sender, RoutedEventArgs e)
        {
            CreateCategoryFrm createCategory = new CreateCategoryFrm(previousWin);
            createCategory.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            createCategory.ShowDialog();
            loadCategories();
        }

        private void SelectedEmployeesNames_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            cbEmployees.IsDropDownOpen = true;
        }

        private void cbEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbEmployees.SelectedIndex = -1;
        }
    }
}
