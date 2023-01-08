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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var users = ConnectionObj.tradeEntities.User.ToList();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserLogin == LoginTxtBox.Text && users[i].UserPassword == PasswordBox.Password && users[i].Role.RoleName == "Администратор")
                {
                    NavigationService.Navigate(new ProductsPage());
                    return;
                }
                else
                {
                    NavigationService.Navigate(new ProductsPageForUser());
                    return;
                }
            }        
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
