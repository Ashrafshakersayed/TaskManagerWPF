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
    /// Interaction logic for CreateCategoryFrm.xaml
    /// </summary>
    public partial class CreateCategoryFrm : Window
    {
        private TeamDetailsFrm teamDetailsFrm;
        public CreateCategoryFrm(TeamDetailsFrm teamDetailsFrm)
        {
            InitializeComponent();
            this.teamDetailsFrm = teamDetailsFrm;
            loadCategory();
        }

        private void loadCategory()
        {
            clbCategoryList.Items.Clear();

            //clbCategoryList.ItemsSource = teamDetailsFrm.SelectedTeam.Categories;
            foreach (var item in teamDetailsFrm.SelectedTeam.Categories)
            {
                clbCategoryList.Items.Add(item);
            }
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxNameCategory.Text.Trim() != string.Empty)
                teamDetailsFrm.SelectedTeam.Categories.Add(textBoxNameCategory.Text.Trim());
            textBoxNameCategory.Text = string.Empty;
            loadCategory();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (string item in clbCategoryList.SelectedItems)
            {
                teamDetailsFrm.SelectedTeam.Categories.Remove(item);
            }
            loadCategory();
        }
    }
}
