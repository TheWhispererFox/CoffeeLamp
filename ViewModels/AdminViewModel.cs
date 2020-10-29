using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CoffeeLamp.Models;

namespace CoffeeLamp.ViewModels
{
    class AdminViewModel
    {
        public ObservableCollection<Coffee> Coffees { get; } = new ObservableCollection<Coffee>();
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
        public ObservableCollection<UserRole> UserRoles { get; } = new ObservableCollection<UserRole>();

        public User NewUser { get; set; }
    }
}
