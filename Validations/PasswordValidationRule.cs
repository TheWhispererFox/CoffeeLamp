using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CoffeeLamp.Validations
{
    class PasswordValidationRule : ValidationRule
    {
        public bool ValidateConfirmPassword { get; set; }
        public string Box1 { get; set; }
        public string Box2 { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace((value as string)?.Trim()))
            {
                return new ValidationResult(false, "Пароль не может быть пустым");
            }

            if (ValidateConfirmPassword)
            {
                if (Box1 != Box2)
                {
                    return new ValidationResult(false, "Пароли должны совпадать");
                }
            }
            return new ValidationResult(true, null);
        }
    }
}
