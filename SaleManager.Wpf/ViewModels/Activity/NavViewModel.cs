using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.ViewModels.Activity
{
    public class NavViewModel
    {
        private readonly INavigationService navigationService;
        public NavViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public void BackNav()
        {
            navigationService.GoBack();
        }
    }
}
