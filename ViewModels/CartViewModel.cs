using CoffeeLamp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CoffeeLamp.ViewModels
{
    class CartViewModel
    {
        public ObservableCollection<Coffee> Coffees { get; } = new ObservableCollection<Coffee>();

        public string Total => Coffees.Sum(coffee => coffee.Price).ToString(CultureInfo.CurrentCulture);
    }
}
