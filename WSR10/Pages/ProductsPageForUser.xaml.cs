using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для ProductsPageForUser.xaml
    /// </summary>
    public partial class ProductsPageForUser : Page
    {
        private int _countBuy = 0;

        public int CountBuy
        {
            get
            {
                return _countBuy;
            }

            set
            {
                _countBuy = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProductsPageForUser()
        {
            InitializeComponent();
            ProductList.ItemsSource = ConnectionObj.tradeEntities.Product.ToList();
            DataContext = this;
            CountBuy = ListObj.products.Count;
        }

        public void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void BuyClick_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SelectedProductsPageForUser());
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentProduct = ConnectionObj.tradeEntities.Product.Where(x => x.ProductName.ToLower().Contains(SearchTxtBox.Text.ToLower())).ToList();

            ProductList.ItemsSource = currentProduct;

            if (SearchTxtBox.Text == "")
            {
                ProductList.ItemsSource = ConnectionObj.tradeEntities.Product.ToList();
            }
        }

        private void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ListObj.products.Count > 8)
            {
                MessageBox.Show("Корзина переполнена");
                return;
            }

            var product = ((sender as Button)).DataContext as Product;

            ListObj.products.Add(product);
            CountBuy++;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox.SelectedIndex == 0)
            {
                var currentProducts = ConnectionObj.tradeEntities.Product.OrderBy(x => x.ProductCost).ToList();

                ProductList.ItemsSource = currentProducts;
            }

            if (ComboBox.SelectedIndex == 1)
            {
                var currentProducts = ConnectionObj.tradeEntities.Product.OrderByDescending(x => x.ProductCost).ToList();

                ProductList.ItemsSource = currentProducts;
            }
        }
    }
}
