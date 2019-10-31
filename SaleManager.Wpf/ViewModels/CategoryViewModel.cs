using Caliburn.Micro;
using Newtonsoft.Json;
using RestSharp;
using SaleManager.Wpf.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.ViewModels
{
    public class CategoryViewModel:Screen
    {
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;
        public NavViewModel NavUC;
        private ActivityBaseViewModel selectedCategory;
        public BindableCollection<ActivityBaseViewModel> Categories { get;}
        public CategoryDetailViewModel detail;
        public CategoryViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;
            var client = new RestClient("https://localhost:44397");
            var request = new RestRequest("api/categories/getall", Method.GET);
            var queryResult = client.Execute<List<CategoryActivityViewModel>>(request).Data;
            Categories = new BindableCollection<ActivityBaseViewModel>(queryResult);
            detail = new CategoryDetailViewModel(eventAggregator);
            
        }
        public ActivityBaseViewModel SelectedCategory
        {
            get { return selectedCategory; }
            set 
            {
                Set(ref selectedCategory, value);
                navigationService.NavigateToViewModel(typeof(CategoryDetailViewModel));
                eventAggregator.PublishOnUIThread(selectedCategory);
            }
        }
    }
}
