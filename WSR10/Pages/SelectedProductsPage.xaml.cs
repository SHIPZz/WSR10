using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WSR10.Classes;
using WSR10.Model;

namespace WSR10.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectedProductsPage.xaml
    /// </summary>
    public partial class SelectedProductsPage : Page
    {
        public SelectedProductsPage()
        {
            InitializeComponent();
            ProductList.ItemsSource = ListObj.products.ToList();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentProduct = ((Button)sender).DataContext as Product;

            ListObj.products.Remove(currentProduct);

            ProductList.ItemsSource = ListObj.products.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }
    }
}