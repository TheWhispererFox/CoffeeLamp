using System;
using System.Collections.Generic;
using System.Security;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        private User user;
        public RegPage()
        {
            InitializeComponent();
            user = new User();
            DataContext = user;
        }

        private void OnLinkClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsValid())
            {
                using CoffeeContext db = new CoffeeContext();
                user.Role = db.Roles.Find("User");
                user.Password = user.Password.GetSha256Hash();
                db.Users.Add(user);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Ошибка: Неправильный ввод данных");
            }
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordValidationRule.Box1 = PasswordPBox.Password;
            PasswordValidationRule.Box2 = RepeatPasswordPbox.Password;
            RepeatPasswordValidationRule.Box1 = PasswordPBox.Password;
            RepeatPasswordValidationRule.Box2 = RepeatPasswordPbox.Password;
        }

        private void RevalidateOnRepeatPasswordDone(object sender, RoutedEventArgs e)
        {
            PasswordValidationRule.Box1 = PasswordPBox.Password;
            PasswordValidationRule.Box2 = RepeatPasswordPbox.Password;
            RepeatPasswordValidationRule.Box1 = PasswordPBox.Password;
            RepeatPasswordValidationRule.Box2 = RepeatPasswordPbox.Password;
            PasswordPBox.GetBindingExpression(AdditionalExtensions.BoundPassword).UpdateSource();
        }
    }
}
