using HotelComplexWPF.Entities;
using HotelComplexWPF.Pages.AdminPages.AddEditPages;
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

namespace HotelComplexWPF.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для CityPage.xaml
    /// </summary>
    public partial class CityPage : Page
    {
        public CityPage()
        {
            InitializeComponent();
            // DGridCity.ItemsSource = HotelEntities.GetContext().City.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditCityPage((sender as Button).DataContext as City));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var cityForRemoving = DGridCity.SelectedItems.Cast<City>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {cityForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try {
                    HotelEntities.GetContext().City.RemoveRange(cityForRemoving);
                    HotelEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridCity.ItemsSource = HotelEntities.GetContext().City.ToList();

                } catch (Exception ex) {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditCityPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                HotelEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p=> p.Reload());
                DGridCity.ItemsSource = HotelEntities.GetContext().City.ToList();
            }
        }
    }
}
