using ForeignLanguagesSchoolApp.model;
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

namespace ForeignLanguagesSchoolApp.pages
{
    /// <summary>
    /// Логика взаимодействия для ClientServicePage.xaml
    /// </summary>
    public partial class ClientServicePage : Page
    {
        Client _currentClient = new Client();
        public ClientServicePage(Client client)
        {
            InitializeComponent();
            if (client != null)
            {
                _currentClient = client;

            }
            DataContext = _currentClient;
            Update();
        }
        public void Update()
        {
            TbClientInfo.Text = $"{_currentClient.FirstName} {_currentClient.LastName} {_currentClient.Patronymic}";
            if (_currentClient.ServiceList.Count > 0)
            {
                LViewService.ItemsSource = _currentClient.ServiceList;
            }
            else
            {
                LViewService.Visibility = Visibility.Hidden;
                spServiceInfo.Children.Clear();
                TextBlock tb = new TextBlock();
                tb.Text = "У данного клиента нет посещений";
                tb.FontSize = 22;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                tb.VerticalAlignment = VerticalAlignment.Center;
                spServiceInfo.Children.Add(tb);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
