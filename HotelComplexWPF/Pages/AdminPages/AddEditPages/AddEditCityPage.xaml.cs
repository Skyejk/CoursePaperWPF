using HotelComplexWPF.Entities;
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

namespace HotelComplexWPF.Pages.AdminPages.AddEditPages
{
    /// <summary>
    /// Логика взаимодействия для AddEditCityPage.xaml
    /// </summary>
    public partial class AddEditCityPage : Page
    {
        private City currentCity = new City();
        public AddEditCityPage(City selectedCity)
        {
            InitializeComponent();

            if (selectedCity != null)
                currentCity = selectedCity;

            DataContext = currentCity;
            cmbxRegion.ItemsSource = HotelEntities.GetContext().Region.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentCity.CityName))
                errors.AppendLine("Укажите название города");
            if (string.IsNullOrWhiteSpace(currentCity.FlagCity))
                errors.AppendLine("Выберите флаг");
            if (currentCity.Region == null)
                errors.AppendLine("Выберите регион");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (currentCity.ID == 0)
                HotelEntities.GetContext().City.Add(currentCity);

            try
            {
                HotelEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
