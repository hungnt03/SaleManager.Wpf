using Caliburn.Micro;
using SaleManager.Wpf.Models;
using SaleManager.Wpf.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.ViewModels
{
    public class BindingsViewModel : Screen
    {
        private ActivityBaseViewModel selectedActivity;

        public BindingsViewModel()
        {
            Activities = new BindableCollection<ActivityBaseViewModel>
            {
                new MessageActivityViewModel(Lipsum.Get()),
                //new PhotoActivityViewModel(Lipsum.Get()),
                new MessageActivityViewModel(Lipsum.Get()),
                //new PhotoActivityViewModel(Lipsum.Get())
            };
        }

        public BindableCollection<ActivityBaseViewModel> Activities { get; }

        public ActivityBaseViewModel SelectedActivity
        {
            get { return selectedActivity; }
            set { Set(ref selectedActivity, value); }
        }
    }
}
