using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.ViewModels
{
    public class FeatureViewModel
    {
        public FeatureViewModel(string title, string description, Type viewModel)
        {
            ViewModel = viewModel;
            Title = title;
            Description = description;
        }

        public string Title { get; }

        public string Description { get; }

        public Type ViewModel { get; }
    }
}
