using System;
using System.Collections.Generic;
using System.Data.Common;
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
using static System.Net.Mime.MediaTypeNames;

namespace BaiguzinAutoservice
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private service_a_import _currentService = new service_a_import();


        public AddEditPage(service_a_import SelectedService)
        {
            InitializeComponent();

            if (SelectedService != null)
                _currentService = SelectedService;

            DataContext = _currentService;
        }

        private void SaveButton_CLick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentService.Title))
                errors.AppendLine("Укажите название улсуги");

            if (_currentService.Cost == 0)
                errors.AppendLine("Укажите стоимсоть услуги");

            if (_currentService.Discount < 0 && _currentService.Discount > 100)
                errors.AppendLine("Укажите свою скидку");
            if (string.IsNullOrWhiteSpace(_currentService.Discount.ToString()))
            {
                _currentService.Discount = 0;
            }

            if (string.IsNullOrWhiteSpace(_currentService.DurationInSeconds))
                errors.AppendLine("Укажите длительность услуги");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentService.ID == 0)
                Baiguzin_autoserviceEntities.GetContext().service_a_import.Add(_currentService);

            try
            {
                Baiguzin_autoserviceEntities.GetContext().SaveChanges();
                MessageBox.Show("информация сохранения");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
