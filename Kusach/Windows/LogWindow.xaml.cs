using System.Linq;
using System.Windows;

namespace Kusach
{
    /// <summary>
    /// Логика взаимодействия для LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        public LogWindow()
        {
            InitializeComponent();
        }
        public void OnLoad(object sender, RoutedEventArgs e)
        {
            logbox.Focus();
        }
        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            if(!Functions.IsValidLogAndPass(logbox.Text, passbox.Password))
                MessageBox.Show("Поля не могут быть пустыми");
            else if (!Functions.LoginCheck(logbox.Text, passbox.Password))
                MessageBox.Show("Неверный логин или пароль");
            else
            {
                profile.DispatcherId = cnt.db.Dispatcher.First(item => item.Login == logbox.Text).IdDispatcher;
                profile.Permission = cnt.db.Dispatcher.First(item => item.Login == logbox.Text).Permission;
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
                
        }
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            RegWindow rw = new RegWindow();
            rw.Show();
            this.Close();
        }
    }
}
