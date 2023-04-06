using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WSR10.Classes;
using WSR10.Model;

namespace WSR10.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Product _product = new Product();

        public AddEditPage(Product product)
        {
            _product = product;
            InitializeComponent();

            if (_product != null)
            {
                NameTxtBox.Text = _product.ProductName;
                PriceTxtBox.Text = _product.ProductCost.ToString();
                DescriptionTxtBox.Text = _product.ProductDescription;
                ManufacturerTxtBox.Text = _product.ProductManufacturer.ToString();
                QuantityInStockTxtBox.Text = _product.ProductQuantityInStock.ToString();
                CategoryProductTxtBox.Text = _product.ProductCategory.ToString();
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            int maxPrice = 80000;
            Product product = new Product();

            if (_product != null)
            {
                _product.ProductName = NameTxtBox.Text;
                _product.ProductManufacturer = ManufacturerTxtBox.Text;
                _product.ProductCategory = CategoryProductTxtBox.Text;
                _product.ProductDescription = DescriptionTxtBox.Text;

                if (_product.ProductCost > maxPrice)
                {
                    MessageBox.Show($"Максимальная цена  - {maxPrice}");
                    return;
                }

                _product.ProductCost = decimal.Parse(PriceTxtBox.Text);
                _product.ProductQuantityInStock = int.Parse(QuantityInStockTxtBox.Text);
                MessageBox.Show("Готово!");
                ConnectionObj.tradeEntities.SaveChanges();
                NavigationService.Navigate(new ProductsPage());
            }
            else
            {
                _product = product;

                _product.ProductName = NameTxtBox.Text;
                _product.ProductManufacturer = ManufacturerTxtBox.Text;
                _product.ProductCategory = CategoryProductTxtBox.Text;
                _product.ProductDescription = DescriptionTxtBox.Text;
                _product.ProductCost = decimal.Parse(PriceTxtBox.Text);

                if (_product.ProductCost > maxPrice)
                {
                    MessageBox.Show($"Максимальная цена  - {maxPrice}");
                    return;
                }

                _product.ProductQuantityInStock = int.Parse(QuantityInStockTxtBox.Text);
                MessageBox.Show("Готово!");
                ConnectionObj.tradeEntities.Product.Add(product);
                ConnectionObj.tradeEntities.SaveChanges();
                NavigationService.Navigate(new ProductsPage());
            }
        }
    }
}