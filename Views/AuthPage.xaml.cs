using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoffeeLamp.Models;

namespace CoffeeLamp
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private User user;
        public AuthPage()
        {
            InitializeComponent();
            user = new User();
            DataContext = user;
        }

        private void OnLinkClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsValid() && !string.IsNullOrWhiteSpace(PasswordPBox.Password))
            {
                using (CoffeeContext db = new CoffeeContext())
                {
                    user = db.Users.Find(LoginTbox.Text.Trim());
                    if (user != null)
                    {
                        if (user.Password == PasswordPBox.Password.GetSha256Hash())
                        {
                            MessageBox.Show("Плейсхолдер успешного входа");
                        }
                        else
                        {
                            MessageBox.Show("Ошибка: Неверный логин или пароль");
                        }
                    }
                    else
                    {
                        //Access denied
                        MessageBox.Show("Ошибка: Неверный логин или пароль");
                    }
                }  
            }
            else
            {
                MessageBox.Show("Ошибка: Неправильный ввод данных", "Ошибка валидации");
            }
            
        }

        private void AuthPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoginTbox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
