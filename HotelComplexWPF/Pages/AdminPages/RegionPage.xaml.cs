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
    /// Логика взаимодействия для RegionPage.xaml
    /// </summary>
    public partial class RegionPage : Page
    {
        public RegionPage()
        {
            InitializeComponent();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditRegionPage((sender as Button).DataContext as Region));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var regionForRemoving = DGridRegion.SelectedItems.Cast<Region>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {regionForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    HotelEntities.GetContext().Region.RemoveRange(regionForRemoving);
                    HotelEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridRegion.ItemsSource = HotelEntities.GetContext().Region.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditRegionPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HotelEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridRegion.ItemsSource = HotelEntities.GetContext().Region.ToList();
            }
        }
    }
}
