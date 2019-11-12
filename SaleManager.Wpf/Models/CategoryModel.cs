using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SaleManager.Wpf.Models
{
    public class CategoryModel:ModelBase
    {
        private int _id { set; get; }
        private string _name { set; get; }
        private string _description { set; get; }

        public override ValidationResult Valid(object value, CultureInfo cultureInfo)
        {
            if(Name.Length>5)
                return new ValidationResult(false, $"Please enter Name < 5 character---");
            return base.Valid(value, cultureInfo);
        }
        public string Description
        {
            get
            { return _description; }
            set
            {
                this._description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                this._name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Id
        {
            get { return _id; }
            set
            {
                this._id = value;
                OnPropertyChanged("Id");
            }
        }
    }
}
