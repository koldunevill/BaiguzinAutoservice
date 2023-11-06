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

        public bool IsServiceExist = false;
        public AddEditPage(service_a_import SelectedService)
        {
            InitializeComponent();

            if (SelectedService != null)
            {
                IsServiceExist = true;
                _currentService = SelectedService;
            }

            DataContext = _currentService;
        }


        private void SaveButton_CLick(object sender, RoutedEventArgs e)
        {
            var errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentService.Title)) errors.AppendLine("Укажите название услуги");
            if (_currentService.Cost == 0) errors.AppendLine("Укажите стоимость услуги");

            if (_currentService.Discount < 0)
                errors.AppendLine("Укажите скидку");
            if (_currentService.Discount > 100)
                errors.AppendLine("Невозможно указать такую скидку");

            if (string.IsNullOrWhiteSpace(_currentService.Discount.ToString()))
                _currentService.Discount = 0;
            if (_currentService.DurationInSeconds < 0 || _currentService.DurationInSeconds > 240)
                errors.AppendLine("Невозможно указать такую длительность");
            if (string.IsNullOrWhiteSpace(_currentService.DurationInSeconds.ToString()))
                _currentService.DurationInSeconds = 0;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            var allServices = Baiguzin_autoserviceEntities.GetContext().service_a_import.ToList();
            allServices = allServices.Where(p => p.Title == _currentService.Title).ToList();
            if (allServices.Count == 0 || IsServiceExist == true)
            {
                if (_currentService.ID == 0)
                {
                    Baiguzin_autoserviceEntities.GetContext().service_a_import.Add(_currentService);
                }

                try
                {
                    Baiguzin_autoserviceEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                Baiguzin_autoserviceEntities.GetContext().SaveChanges();
                MessageBox.Show("Уже существует такая услуга");
            }
        }
    }
}
