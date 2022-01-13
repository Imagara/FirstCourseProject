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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kusach.Pages
{
    /// <summary>
    /// Логика взаимодействия для PointsListPage.xaml
    /// </summary>
    public partial class PointsListPage : Page
    {
        public PointsListPage()
        {
            InitializeComponent();
            PointsList.ItemsSource = cnt.db.Points.ToList();
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Windows.PointEditWindow dew = new Windows.PointEditWindow(((Points)PointsList.SelectedItem).IdPoint);
            dew.Show();
        }

        #region Поиск
        private void SearchBoxPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SearchBox.Text == "Поиск...")
                SearchBox.Text = "";
        }
        private void SearchLostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "")
                SearchBox.Text = "Поиск...";
        }
        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox.Text != "" && SearchBox.Text != "Поиск...")
                PointsList.ItemsSource = cnt.db.Points.Where(item => (item.IdPoint + " " + item.Name + " " + item.location).Contains(SearchBox.Text)).ToList();
            else
                cnt.db.Points.ToList();
        }
        #endregion
        private void AddPointButton_Click(object sender, RoutedEventArgs e)
        {
            AddPointWindow adw = new AddPointWindow();
            adw.Show();
        }

        private void DeletePointsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdatePointsButton_Click(object sender, RoutedEventArgs e)
        {
            PointsList.ItemsSource = cnt.db.Points.ToList();
        }
    }
}
