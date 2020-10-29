using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace CoffeeLamp.Validations
{
    class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value as string)?.Trim()) ? new ValidationResult(false, "Имя не может быть пустым") : new ValidationResult(true, null);
        }
    }
}
