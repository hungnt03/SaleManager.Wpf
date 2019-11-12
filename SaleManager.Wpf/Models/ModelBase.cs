using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SaleManager.Wpf.Models
{
    public class ModelBase : ValidationRule,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return Valid(value, cultureInfo);
        }

        public virtual ValidationResult Valid(object value, CultureInfo cultureInfo)
        {
            return ValidationResult.ValidResult;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
