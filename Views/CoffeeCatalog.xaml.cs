using System;
using System.Collections.Generic;
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
using CoffeeLamp.ViewModels;

namespace CoffeeLamp
{
    /// <summary>
    /// Логика взаимодействия для CoffeeCatalog.xaml
    /// </summary>
    public partial class CoffeeCatalog : Page
    {
        public CoffeeCatalog()
        {
            InitializeComponent();
            DataContext = new CoffeeViewModel();
        }

        private void DragStart(object sender, MouseEventArgs e)
        {
            Card card = sender as Card;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(card, card.DataContext, DragDropEffects.Move);
            }
        }
    }
}
