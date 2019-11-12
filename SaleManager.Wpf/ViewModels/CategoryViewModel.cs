using Caliburn.Micro;
using Newtonsoft.Json;
using SaleManager.Wpf.Inflastructors;
using SaleManager.Wpf.Models;
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
        public BindableCollection<ActivityBaseViewModel> Categories { get; } = new BindableCollection<ActivityBaseViewModel>();
        public CategoryDetailViewModel detail;
        public CategoryViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe(this);

            detail = new CategoryDetailViewModel(eventAggregator);
            InitList();
        }

        private async void InitList()
        {
            var json = await RestApiUtils.Instance.Get("api/category/getall");
            var datas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CategoryModel>>(json);
            var cates = new BindableCollection<ActivityBaseViewModel>();
            foreach(var elm in datas)
            {
                Categories.Add(new CategoryActivityViewModel(elm.Id, elm.Name, elm.Description));
            }
        }

        public void OnCreateCategory()
        {
            navigationService.NavigateToViewModel(typeof(CategoryDetailViewModel));
        }
        public ActivityBaseViewModel SelectedCategory
        {
            get { return selectedCategory; }
            set 
            {
                Set(ref selectedCategory, value);
                NotifyOfPropertyChange(() => SelectedCategory);
                navigationService.NavigateToViewModel<CategoryDetailViewModel>(detail);
                eventAggregator.PublishOnUIThread(selectedCategory);
            }
        }
    }
}
