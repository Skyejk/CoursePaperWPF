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
    /// Логика взаимодействия для AddEditRegionPage.xaml
    /// </summary>
    public partial class AddEditRegionPage : Page
    {
        private Region currentRegion = new Region();
        public AddEditRegionPage(Region selectedRegion)
        {
            InitializeComponent();

            if (selectedRegion != null)
                currentRegion = selectedRegion;

            DataContext = currentRegion;
            cmbxCountry.ItemsSource = HotelEntities.GetContext().Country.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentRegion.RegionName))
                errors.AppendLine("Укажите название региона");
            if (string.IsNullOrWhiteSpace(currentRegion.RegionOKATO))
                errors.AppendLine("Укажите ОКАТО региона");
            if (string.IsNullOrWhiteSpace(currentRegion.FlagRegion))
                errors.AppendLine("Выберите флаг");
            if (currentRegion.Country == null)
                errors.AppendLine("Выберите страну");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (currentRegion.ID == 0)
                HotelEntities.GetContext().Region.Add(currentRegion);

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
