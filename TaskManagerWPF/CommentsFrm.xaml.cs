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
    /// Interaction logic for CommentsFrm.xaml
    /// </summary>
    public partial class CommentsFrm : Window
    {
        public List<string> Comments { get; set; }
        TaskDetailsFrm prevForm;
        BusinessLayer.Task task;
        public CommentsFrm(TaskDetailsFrm prevForm, BusinessLayer.Task task)
        {
            InitializeComponent();
            //TODO Inialize Comments List from priveos Win. Change next line
            this.prevForm = prevForm;
            this.task = task;
            Comments = task.Comments;
            DrowComments();

        }

        private void DrowComments()
        {
            foreach (string commentText in Comments)
            {
                commentBox comment = new commentBox(commentText);
                CommentsContainer.Children.Add(comment);
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            textMsgBox.SelectAll();
            string Msg = textMsgBox.Selection.Text;
            commentBox comment = new commentBox(Msg);
            CommentsContainer.Children.Add(comment);
            scrollerView.ScrollToBottom();
            Comments.Add(Msg);
            textMsgBox.Document.Blocks.Clear();
        }

        private void textMsgBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSend.IsEnabled = new TextRange(textMsgBox.Document.ContentStart, textMsgBox.Document.ContentEnd).Text.Trim() != "";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
