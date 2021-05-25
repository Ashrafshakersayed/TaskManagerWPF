using BusinessLayer;
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

namespace TaskManagerWPF
{
    /// <summary>
    /// Interaction logic for TaskDetailsFrm.xaml
    /// </summary>
    public partial class TaskDetailsFrm : Window
    {
        private BusinessLayer.Task task;
        Team SelectedTeam;
        public TaskDetailsFrm(Team SelectedTeam, BusinessLayer.Task task)
        {
            InitializeComponent();
            this.task = task;
            txtName.Text = task.Name;
            dtpDeadLine.SelectedDate = task.Deadline;
            this.SelectedTeam = SelectedTeam;

            cmbPriority.ItemsSource = new List<TaskPriority> {
                TaskPriority.High,
                TaskPriority.Medium,
                TaskPriority.Low
            };
            cmbPriority.SelectedItem = task.Priority;

            cmbCategory.ItemsSource = SelectedTeam.Categories;
            cmbCategory.SelectedItem = task.Category;
            LoadLists();

            if (task.State == TaskState.Finished)
            {
                //panelContent.Enabled = false;
                ItemsToDisable();
            }
        }

        private void ItemsToDisable()
        {
            btnEditEmp.IsEnabled = false;
            btnEditFile.IsEnabled = false;
            btnEditSubTask.IsEnabled = false;
            btnUpdateTask.IsEnabled = false;
            txtName.IsEnabled = false;
            dtpDeadLine.IsEnabled = false;
            cmbCategory.IsEnabled = false;
            cmbPriority.IsEnabled = false;
        }

        private void LoadLists()
        {
            clbSubTasks.Items.Clear();
            foreach (var item in task.SubTasks)
            {
                clbSubTasks.Items.Add(item); //, item.CheckSubTask);
            }
            lsbEmployees.Items.Clear();
            foreach (var item in task.Employees)
            {
                lsbEmployees.Items.Add(item);
            }
            lsbFiles.Items.Clear();
            foreach (var item in task.Files)
            {
                lsbFiles.Items.Add(item);
            }
        }



        private void BtnEditFile_Click(object sender, RoutedEventArgs e)
        {
            EditFilesFrm editFilesFrm = new EditFilesFrm(task.Files);
            editFilesFrm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editFilesFrm.ShowDialog();
            LoadLists();
        }

        private void BtnEditEmp_Click(object sender, RoutedEventArgs e)
        {
            EditEmployeeFrm editEmployeeFrm = new EditEmployeeFrm(task.Employees, SelectedTeam.Employees, ComeFrom.TaskForm);
            editEmployeeFrm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editEmployeeFrm.ShowDialog();
            LoadLists();
        }

        private void BtnEditSubTask_Click(object sender, RoutedEventArgs e)
        {
            EditSubTaskList editSubTaskList = new EditSubTaskList(task.SubTasks);
            editSubTaskList.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editSubTaskList.ShowDialog();
            LoadLists();
        }

        private void BtnComment_Click(object sender, RoutedEventArgs e)
        {
            CommentsFrm comments = new CommentsFrm(this, task);
            comments.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            comments.ShowDialog();
        }

        private void BtnUpdateTask_Click(object sender, RoutedEventArgs e)
        {
            task.Name = txtName.Text;
            task.Deadline = dtpDeadLine.SelectedDate.Value;         //?? DateTime.Now;
            task.Priority = (TaskPriority)cmbPriority.SelectedItem;
            task.Category = cmbCategory.SelectedItem.ToString();

            foreach (SubTask item in clbSubTasks.SelectedItems)
            {
                item.CheckSubTask = true;
            }

            if (clbSubTasks.SelectedItems.Count == clbSubTasks.Items.Count)
            {
                task.State = TaskState.Finished;
            }
            this.Close();
        }

        private void LsbFiles_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (lsbFiles.SelectedItem != null)
            //{
            //    string path = lsbFiles.SelectedItem.ToString();
            //    string extension = Path.GetExtension(path).ToLower();
            //    if (extension == ".pdf")
            //    {
            //        PdfViewerFrm pdfViewerFrm = new PdfViewerFrm(path);
            //        pdfViewerFrm.ShowDialog();
            //    }
            //    else if (extension == ".docx" || extension == ".doc")
            //    {
            //        WordViewerFrm wordViewerFrm = new WordViewerFrm(path);
            //        wordViewerFrm.ShowDialog();
            //    }
            //    else if (extension == ".jpg" || extension == ".bmp" || extension == ".gif" || extension == ".png")
            //    {
            //        ImageViewerFrm imageViewerFrm = new ImageViewerFrm(path);
            //        imageViewerFrm.ShowDialog();
            //    }
            //}
        }
    }
}
