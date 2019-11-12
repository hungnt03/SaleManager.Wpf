using SaleManager.Wpf.Models;
using SaleManager.Wpf.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.ViewModels.Activity
{
    public class CategoryActivityViewModel : ActivityBaseViewModel
    {
        

        public override string Title => "category";
        private CategoryModel _category { set; get; } 

        public CategoryActivityViewModel() { }
        public CategoryActivityViewModel(int id, string name, string description)
        {
            Category = new CategoryModel() { Id = id, Name = name, Description = description };
        }

        public CategoryModel Category
        {
            get
            { return _category; }
            set
            {
                this._category = value;
                NotifyOfPropertyChange(() => Category);
            }
        }
    }
}