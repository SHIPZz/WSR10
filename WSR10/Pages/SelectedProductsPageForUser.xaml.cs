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
using WSR10.Classes;
using WSR10.Model;

namespace WSR10.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectedProductsPageForUser.xaml
    /// </summary>
    public partial class SelectedProductsPageForUser : Page
    {
        public SelectedProductsPageForUser()
        {
            InitializeComponent();
            ProductList.ItemsSource = ListObj.products.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPageForUser());
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentProduct = ((Button)sender).DataContext as Product;

            ListObj.products.Remove(currentProduct);

            ProductList.ItemsSource = ListObj.products.ToList();
        }
    }
}
