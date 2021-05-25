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
    /// Interaction logic for EditEmployeeFrm.xaml
    /// </summary>
    public partial class EditEmployeeFrm : Window
    {
        Dictionary<int, Employee> EmployeeDic;
        private List<Employee> CurrentEmployees;
        private List<Employee> AllEmployees;
        private ComeFrom comeFrom;
        private List<BusinessLayer.Task> tasks;
        public EditEmployeeFrm(List<Employee> CurrentEmployees, List<Employee> AllEmployees, ComeFrom comeFrom, List<BusinessLayer.Task> tasks = null)
        {
            InitializeComponent();
            this.AllEmployees = AllEmployees;
            this.CurrentEmployees = CurrentEmployees;
            this.comeFrom = comeFrom;
            if (tasks != null)
                this.tasks = tasks;
            LoadEmployees();
        }

        private void LoadEmployees()
        {

            clbTaskEmployeeList.Items.Clear();
            foreach (var item in CurrentEmployees)
            {
                clbTaskEmployeeList.Items.Add(item);
            }

            EmployeeDic = new Dictionary<int, Employee>();
            int i = 0;
            cmbTeamEmployees.Items.Clear();
            foreach (var item in AllEmployees)
            {
                if (!CurrentEmployees.Contains(item))
                {
                    cmbTeamEmployees.Items.Add(item);
                    EmployeeDic[i++] = item;
                }

            }
            if (cmbTeamEmployees.Items.Count > 0)
            {
                cmbTeamEmployees.SelectedIndex = 0;
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (comeFrom == ComeFrom.TaskForm)
            {
                foreach (Employee item in clbTaskEmployeeList.SelectedItems)
                {
                    CurrentEmployees.Remove(item);
                }
            }
            else if (comeFrom == ComeFrom.TeamForm)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (Employee employee in clbTaskEmployeeList.SelectedItems)
                {
                    bool CanDelete = true;
                    foreach (var t in tasks)
                    {

                        if (t.Employees.Contains(employee) && t.State == TaskState.NotFinished)
                        {
                            CanDelete = false;
                            stringBuilder.Append(employee + ", ");
                        }
                    }
                    if (CanDelete)
                    {
                        CurrentEmployees.Remove(employee);
                    }
                }
                if (stringBuilder.Length != 0)
                    MessageBox.Show("Can't delete these Employees : " + stringBuilder.Remove(stringBuilder.Length - 2, 2));
            }

            LoadEmployees();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTeamEmployees.Items.Count > 0)
                CurrentEmployees.Add(EmployeeDic[cmbTeamEmployees.SelectedIndex]);
            LoadEmployees();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
