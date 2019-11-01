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
        private int id { set; get; }
        private string name { set; get; }
        private string description { set; get; }

        public override string Title => "category";
        public string Description
        {
            get
            { return description; }
            set
            {
                this.description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                this.name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
        public int Id
        {
            get { return id; }
            set
            {
                this.id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }
    }
}