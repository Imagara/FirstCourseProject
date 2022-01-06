using System.Windows;

namespace Kusach
{
    /// <summary>
    /// Логика взаимодействия для DeleteUserWindow.xaml
    /// </summary>
    public partial class DeleteUserWindow : Window
    {
        public DeleteUserWindow()
        {
            InitializeComponent();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteList.Text == "" || DeleteBox.Text == "")
                MessageBox.Show("Поля не могут быть пустыми.");
            else
            {
                //cnt.db.Users.Remove();
                //cnt.db.SaveChanges();
                MessageBox.Show("Пользователь успешно удален.");
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
