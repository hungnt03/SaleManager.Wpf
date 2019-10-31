using Caliburn.Micro;
using RestSharp;
using SaleManager.Wpf.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.ViewModels
{
    public class CategoryDetailViewModel : Screen, IHandle<ActivityBaseViewModel>
    {
        private readonly IEventAggregator eventAggregator;
        public string SubmitCaption { get; set; }
        private CategoryActivityViewModel category;
        public CategoryDetailViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
        }
        public CategoryActivityViewModel Category
        {
            get { return category; }
            set
            {
                Set(ref category, value);
            }
        }

        public void Handle(ActivityBaseViewModel message)
        {
            if(message.GetType() == typeof(CategoryActivityViewModel))
            {
                var source = (CategoryActivityViewModel)message;
                var client = new RestClient("https://localhost:44397");
                var request = new RestRequest("api/categories/getbyid/" + source.Id, Method.GET);
                var queryResult = client.Execute<CategoryActivityViewModel>(request).Data;
                Category = queryResult;
            }
        }
    }
}
