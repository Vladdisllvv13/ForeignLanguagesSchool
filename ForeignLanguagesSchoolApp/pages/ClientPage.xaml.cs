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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private string fnd = "";
        private bool _isBirthday = false;
        private int _currentPage = 0;
        public ClientPage()
        {
            InitializeComponent();
            DataContext = this;
            Update();
        }
        public string[] SortingList { get; set; } =
        {
            "Без сортировки",
            "По возрастанию фамилии",
            "По убыванию фамилии",
            "По возрастанию даты последнего посещения",
            "По убыванию даты последнего посещения",
            "По возрастанию посещений",
            "По убыванию посещений"
        };

        public string[] FilterList { get; set; } =
        {
            "Все",
            "Мужской",
            "Женский"
        };

        public string[] CountList { get; set; } =
        {
            "Все",
            "10",
            "25",
            "50"
        };

        public void Update()
        {
            var result = ForeignLanguagesSchoolEntities.GetContext().Client.ToList();
            if (cmbSorting.SelectedIndex == 1) result = result.OrderBy(c => c.FirstName).ToList();
            if (cmbSorting.SelectedIndex == 2) result = result.OrderByDescending(c => c.FirstName).ToList();
            if (cmbSorting.SelectedIndex == 3) result = result.OrderBy(c => c.DateService).ToList();
            if (cmbSorting.SelectedIndex == 4) result = result.OrderByDescending(c => c.DateService).ToList();
            if (cmbSorting.SelectedIndex == 5) result = result.OrderBy(c => c.CountService).ToList();
            if (cmbSorting.SelectedIndex == 6) result = result.OrderByDescending(c => c.CountService).ToList();

            if (cmbFilter.SelectedIndex != 0) result = result.Where(c => c.GenderCode == cmbFilter.SelectedIndex.ToString()).ToList();
            result = result.Where(c => c.FirstName.ToLower().Contains(fnd.ToLower())
                          || c.LastName.ToLower().Contains(fnd.ToLower())
                          || c.Patronymic.ToLower().Contains(fnd.ToLower())
                          || c.Email.ToLower().Contains(fnd.ToLower())
                          || c.Phone.ToLower().Contains(fnd.ToLower())).ToList();

            if (_isBirthday) result = result.Where(c => c.Birthday.HasValue && c.Birthday.Value.Month == DateTime.Now.Month).ToList();

            int currentCount = result.Count();
            int fullCount = ForeignLanguagesSchoolEntities.GetContext().Client.Count();
            txtClients.Text = $"{currentCount} из {fullCount}";

            if (cmbCount.SelectedIndex != 0 && cmbCount.SelectedItem != null) result = result.Skip(_currentPage * Int32.Parse(cmbCount.SelectedValue.ToString()))
                                                                                                .Take(Int32.Parse(cmbCount.SelectedValue.ToString())).ToList();

            lvClients.ItemsSource = result;



            int ost = 0;
            int pag = 1;
            if (cmbCount.SelectedIndex != 0 && cmbCount.SelectedItem != null)
            {
                ost = currentCount % Int32.Parse(cmbCount.SelectedValue.ToString());
                pag = (currentCount - ost) / Int32.Parse(cmbCount.SelectedValue.ToString());
            }
            if (ost > 0) pag++;
            paginPanel.Children.Clear();
            for (int i = 0; i < pag; i++)
            {
                Button myButton = new Button();
                myButton.Height = 30;
                myButton.Content = i + 1;
                myButton.Width = 20;
                myButton.Background = new SolidColorBrush(Colors.White);
                myButton.BorderBrush = new SolidColorBrush(Colors.White);
                myButton.Cursor = Cursors.Hand;
                myButton.HorizontalAlignment = HorizontalAlignment.Center;
                myButton.Tag = i;
                myButton.Click += new RoutedEventHandler(paginButton_Click);
                paginPanel.Children.Add(myButton);
                if (i == _currentPage) myButton.Background = new SolidColorBrush((Color)Colors.PaleTurquoise);
            }
            turnButton(currentCount);
        }

        private void turnButton(int count)
        {
            try
            {
                if (_currentPage == 0) { btBack.IsEnabled = false; }
                else { btBack.IsEnabled = true; };
                if (cmbCount.SelectedIndex != 0 && cmbCount.SelectedItem != null)
                {
                    if ((_currentPage + 1) * Int32.Parse(cmbCount.SelectedValue.ToString()) >= count) { btForward.IsEnabled = false; }
                    else { btForward.IsEnabled = true; }
                }
                else { btForward.IsEnabled = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void paginButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = Convert.ToInt32(((Button)sender).Tag.ToString());
            Update();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _currentPage = 0;
            fnd = txtSearch.Text;
            Update();
        }

        private void cmbSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentPage = 0;
            Update();
        }

        private void cmbCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentPage = 0;
            Update();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _currentPage = 0;
            _isBirthday = true;
            Update();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _currentPage = 0;
            _isBirthday = false;
            Update();
        }

        private void lvClients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AddEditClientPage(lvClients.SelectedItem as Client));
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditClientPage(null));
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage >= 0)
            {
                _currentPage--;
                Update();
            }
        }

        private void btForward_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbCount.SelectedIndex != 0 && cmbCount.SelectedItem != null)
                {
                    if (_currentPage < ForeignLanguagesSchoolEntities.GetContext().Client.Count() / Int32.Parse(cmbCount.SelectedValue.ToString()) - 1)
                    {
                        _currentPage++;
                        Update();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvClients.SelectedItems.Count > 0)
            {
                if (MessageBox.Show($"Вы действительно хотите удалить {lvClients.SelectedItems.Count} агента(ов)?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        StringBuilder errors = new StringBuilder();
                        var selected = lvClients.SelectedItems.Cast<Client>().ToArray();
                        int clientCount = 0;
                        foreach (var client in selected)
                        {
                            if (client.ClientService.Count > 0)
                            {
                                errors.AppendLine($"Клиент {client.ID} не может быть удален, т.к. есть информация о реализации продукции");
                            }
                            else
                            {
                                foreach (Tag shop in client.Tag)
                                {
                                    ForeignLanguagesSchoolEntities.GetContext().Tag.Remove(shop);
                                }
                                ForeignLanguagesSchoolEntities.GetContext().Client.Remove(client);
                                ForeignLanguagesSchoolEntities.GetContext().SaveChanges();
                                clientCount++;
                            }
                        }
                        if (errors.Length > 0)
                        {
                            MessageBox.Show(errors.ToString());
                        }
                        if (clientCount != 0)
                        {
                            MessageBox.Show($"Удалено агентов: {clientCount}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        Update();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Выберите агента для удаления", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ClientService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new ClientServicePage(lvClients.SelectedItem as Client));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
