using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CoffeeLamp.Models;
using CoffeeLamp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CoffeeLamp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CartPopup.DataContext = new CartViewModel();
        }

        private void NavigateTo(object sender, RoutedEventArgs e)
        {
            foreach (Button child in (VisualTreeHelper.GetParent(sender as Button) as StackPanel).Children)
            {
                child.Foreground = Brushes.White;
                child.BorderBrush = Brushes.Transparent;
            }
            Button senderButton = sender as Button;
            senderButton.Foreground = Application.Current.Resources["SelectedColor"] as SolidColorBrush;
            senderButton.BorderBrush = Application.Current.Resources["SelectedColor"] as SolidColorBrush;
            switch (senderButton.Tag)
            {
                case "Coffee":
                    MainFrame.Navigate(new CoffeeCatalog());
                    break;
                case "Auth":
                    MainFrame.Navigate(new AuthPage());
                    break;
                default:
                    break;
            }

            e.Handled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CoffeeContext db = new CoffeeContext();
            db.Roles.Find("Admin");
            if (!db.Roles.Any())
            {
                try
                {
                    db.Roles.AddRange(new List<UserRole>()
                    {
                        new UserRole() {Role = "User"}, new UserRole() {Role = "Employee"},
                        new UserRole() {Role = "Admin"}
                    });
                    db.SaveChanges();
                    db.Users.Add(new User()
                    {
                        Login = "Admin", Password = "Admin".GetSha256Hash(), RoleFK = "Admin", Name = "John",
                        Surname = "Doe"
                    });
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }

                db.Dispose();
            }

            e.Handled = true;
        }

        private void ToggleCart(object sender, RoutedEventArgs e)
        {
            CartPopup.IsOpen = !CartPopup.IsOpen;
            e.Handled = true;
        }

        private void OnCartDrop(object sender, DragEventArgs e)
        {
            ListBox list = sender as ListBox;
            (list.ItemsSource as ObservableCollection<Coffee>).Add(e.Data.GetData(typeof(Coffee)) as Coffee);
            TotalBlock.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }
    }
}
