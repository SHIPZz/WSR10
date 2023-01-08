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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Product _product = new Product();

        public AddEditPage(Product product)
        {
            _product = product;
            InitializeComponent();

            //Если мы передаем пустой обьект, значит, пользователь не нажал на кнопку редактировать и ничего не получил с этой кнопки, следовательно, у нас сработала кнопка Добавить

            if(_product != null)
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

            if(_product != null)
            {
                //Здесь, если был получен какой-то обьект, значит нажали кнопку редактировать
                _product.ProductName = NameTxtBox.Text;
                _product.ProductManufacturer = ManufacturerTxtBox.Text;
                _product.ProductCategory = CategoryProductTxtBox.Text;
                _product.ProductDescription = DescriptionTxtBox.Text;

                if(_product.ProductCost > maxPrice)
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
                //Вот тут записываются данные, если была кнопка добавить
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
