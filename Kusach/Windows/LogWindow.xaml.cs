using System;
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
                MessageBox.Show("Поля не могут быть пустыми.");
            if (Functions.LoginCheck(logbox.Text, passbox.Password))
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            RegWindow rw = new RegWindow();
            rw.Show();
            this.Close();
        }
    }
}
