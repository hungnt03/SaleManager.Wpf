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
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }

        public override string Title => "category";
    }
}
