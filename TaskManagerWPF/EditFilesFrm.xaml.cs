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

namespace TaskManagerWPF
{
    /// <summary>
    /// Interaction logic for EditFilesFrm.xaml
    /// </summary>
    public partial class EditFilesFrm : Window
    {
        private List<string> files;
        public EditFilesFrm(List<string> files)
        {
            InitializeComponent();
            this.files = files;
            LoadFiles();
        }
        private void LoadFiles()
        {

            clbFilesList.Items.Clear();
            foreach (var item in files)
            {
                clbFilesList.Items.Add(item);
            }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in clbFilesList.SelectedItems)
            {
                files.Remove(item.ToString());
            }
            LoadFiles();
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF |*.pdf|doc|*.doc;*.docx|Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if ((bool)fileDialog.ShowDialog())
            {
                //TBfilePath.Text = fileDialog.FileName;
                files.Add(fileDialog.FileName);
                clbFilesList.Items.Add(fileDialog.FileName);
            }
        }
    }
}
