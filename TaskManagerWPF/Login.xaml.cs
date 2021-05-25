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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            BusinessLayer.Program.Start();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            TeamsList teamsList = new TeamsList();
            this.Hide();
            teamsList.ShowDialog();
            this.Close();
        }
    }
}
