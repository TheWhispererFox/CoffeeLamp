using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;
using CoffeeLamp.Annotations;

namespace CoffeeLamp.Models
{
    class User : INotifyPropertyChanged
    {
        private string login;
        private string password;
        private string name;
        private string surname;
        private string roleFk;

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        [Required]
        public string Password
        {
            get => password; 
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        [Required]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        [Required]
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged(surname);
            }
        }
        [Required]
        public string RoleFK
        {
            get => roleFk;
            set
            {
                roleFk = value;
                OnPropertyChanged(nameof(RoleFK));
            }
        }
        public UserRole Role { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
