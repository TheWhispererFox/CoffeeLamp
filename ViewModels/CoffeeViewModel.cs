using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CoffeeLamp.Models;

namespace CoffeeLamp.ViewModels
{
    class CoffeeViewModel
    {
        private ObservableCollection<Coffee> coffees;

        public CoffeeViewModel()
        {
            coffees = new ObservableCollection<Coffee>
            {
                new Coffee()
                {
                    Name = "Каппучино",
                    Price = 200,
                    Description = "Самый вкусный кофе - это конечно Каппучино"
                },
                new Coffee()
                {
                    Name = "Американо",
                    Price = 205,
                    Description = "Самый бодрящий кофе - это конечно Американо"
                },
                new Coffee()
                {
                    Name = "Эспрессо",
                    Price = 210,
                    Description = "Самый крепкий кофе - это конечно Эспрессо"
                },
                new Coffee()
                {
                    Name = "Просто кофе",
                    Price = 210,
                    Description = "Самый кофе - это конечно кофе"
                }
            };
        }

        public ObservableCollection<Coffee> Coffees
        {
            get => coffees;
        }
    }
}
