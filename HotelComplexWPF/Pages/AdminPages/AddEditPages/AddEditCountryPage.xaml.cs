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
    /// Логика взаимодействия для AddEditCountryPage.xaml
    /// </summary>
    public partial class AddEditCountryPage : Page
    {
        private Country currentCountry = new Country();
        public AddEditCountryPage(Country selectedCountry)
        {
            InitializeComponent();

            if (selectedCountry != null)
                currentCountry = selectedCountry;

            DataContext = currentCountry;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentCountry.CodeCountry))
                errors.AppendLine("Укажите код страны");
            if (string.IsNullOrWhiteSpace(currentCountry.ShortName))
                errors.AppendLine("Укажите название страны");
            if (string.IsNullOrWhiteSpace(currentCountry.FullName))
                errors.AppendLine("Укажите полное название страны");
            if (string.IsNullOrWhiteSpace(currentCountry.FlagCountry))
                errors.AppendLine("Выберите флаг");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (currentCountry.ID == 0)
                HotelEntities.GetContext().Country.Add(currentCountry);

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
