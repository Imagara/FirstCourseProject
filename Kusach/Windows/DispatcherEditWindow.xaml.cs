using System;
using System.Linq;
using System.Windows;

namespace Kusach.Windows
{
    public partial class DispatcherEditWindow : Window
    {
        Dispatcher dispatcher;
        public DispatcherEditWindow(int id)
        {
            InitializeComponent();
            dispatcher = cnt.db.Dispatcher.Where(item => item.IdDispatcher == id).FirstOrDefault();
            PermissionBox.Text = dispatcher.Permission.ToString();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Functions.IsOnlyDigits(PermissionBox.Text))
            {
                dispatcher.Permission = Convert.ToInt32(PermissionBox.Text);
                cnt.db.SaveChanges();
                if (profile.DispatcherId == dispatcher.IdDispatcher)
                    profile.Permission = Convert.ToInt32(PermissionBox.Text);
                this.Close();
            }
            else
                MessageBox.Show("Данное поле может содержать только цифры");
        }
    }
}
