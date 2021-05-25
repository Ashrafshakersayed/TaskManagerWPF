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
    /// Interaction logic for EditSubTaskList.xaml
    /// </summary>
    public partial class EditSubTaskList : Window
    {
        private List<SubTask> subTasks;
        public EditSubTaskList(List<SubTask> subTasks)
        {
            InitializeComponent();
            this.subTasks = subTasks;
            LoadSubTasks();
        }

        private void LoadSubTasks()
        {
            clbSubTasks.Items.Clear();
            foreach (var item in subTasks)
            {
                clbSubTasks.Items.Add(item);
            }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (SubTask item in clbSubTasks.SelectedItems)
            {
                subTasks.Remove(item);
            }
            LoadSubTasks();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            SubTask st = new SubTask(txtSubTaskName.Text);
            clbSubTasks.Items.Add(st);
            subTasks.Add(st); //Add to Main SubTasks List
            txtSubTaskName.Text = string.Empty;
        }
    }
}
