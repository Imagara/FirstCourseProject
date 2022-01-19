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

namespace Kusach.Windows
{
    /// <summary>
    /// Логика взаимодействия для DispatcherEditWindow.xaml
    /// </summary>
    public partial class DispatcherEditWindow : Window
    {
        int dispatcherId;
        public DispatcherEditWindow(int id)
        {
            InitializeComponent();
            dispatcherId = id;
            PermissionBox.Text = cnt.db.Dispatcher.Where(item => item.IdDispatcher == id).Select(item => item.Permission).FirstOrDefault().ToString();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Functions.IsOnlyDigits(PermissionBox.Text))
            {
                Dispatcher dispatcher = cnt.db.Dispatcher.Where(item => item.IdDispatcher == dispatcherId).FirstOrDefault();
                dispatcher.Permission = Convert.ToInt32(PermissionBox.Text);
                cnt.db.SaveChanges();
                if (profile.DispatcherId == dispatcherId)
                    profile.Permission = Convert.ToInt32(PermissionBox.Text);
                this.Close();
            }
            else
                MessageBox.Show("Данное поле может содержать только цифры");
        }
    }
}
