using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kusach.Pages
{
    public partial class PointsListPage : Page
    {
        public PointsListPage()
        {
            InitializeComponent();
            PointsList.ItemsSource = cnt.db.Points.ToList();
            if (profile.Permission != 0)
                CreateButton.Visibility = Visibility.Collapsed;
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (profile.Permission == 0)
                new Windows.PointEditWindow(((Points)PointsList.SelectedItem).IdPoint).Show();
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

        private void UpdatePointsButton_Click(object sender, RoutedEventArgs e)
        {
            PointsList.ItemsSource = cnt.db.Points.ToList();
        }
    }
}
