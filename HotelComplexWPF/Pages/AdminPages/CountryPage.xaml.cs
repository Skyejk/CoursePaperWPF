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
    /// Логика взаимодействия для CountryPage.xaml
    /// </summary>
    public partial class CountryPage : Page
    {
        public CountryPage()
        {
            InitializeComponent();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditCountryPage((sender as Button).DataContext as Country));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var countryForRemoving = DGridCountry.SelectedItems.Cast<Country>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {countryForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    HotelEntities.GetContext().Country.RemoveRange(countryForRemoving);
                    HotelEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridCountry.ItemsSource = HotelEntities.GetContext().Country.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditCountryPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HotelEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridCountry.ItemsSource = HotelEntities.GetContext().Country.ToList();
            }
        }
    }
}
