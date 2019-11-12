using Caliburn.Micro;
using SaleManager.Wpf.Inflastructors;
using SaleManager.Wpf.Models;
using SaleManager.Wpf.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.ViewModels
{
    public class CategoryDetailViewModel : Screen, IHandle<ActivityBaseViewModel>
    {
        private readonly IEventAggregator eventAggregator;
        private string _submitCaption;
        public string SubmitCaption { get 
            {return this._submitCaption;} 
            set
            {
                this.Set(ref _submitCaption, value);
                NotifyOfPropertyChange(() => _submitCaption);
            }
        }
        private CategoryModel _category { set; get; }
        private string _name { set; get; }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
        public CategoryModel Category
        {
            get { return _category; }
            set
            {
                //if (_category == null)
                //    _category = new CategoryActivityViewModel();
                //_category.Id = value.Id;
                //_category.Name = value.Name;
                //_category.Description = value.Description;
                //OnPropertyChanged(new PropertyChangedEventArgs("Category"));
                
                _category = value;
                NotifyOfPropertyChange(() => Category);
            }
        }
        public CategoryDetailViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
            //SubmitCaption = "Cập nhật";
            //Category = new CategoryActivityViewModel();
            //Category.Name = "aa";
        }

        public void Handle(ActivityBaseViewModel message)
        {
            if(message.GetType() == typeof(CategoryActivityViewModel))
            {
                //var source = (CategoryActivityViewModel)message;
                //if (source.Id != 0)
                //    SubmitCaption = "Cập nhật";
                //else
                //    SubmitCaption = "Thêm mới";
                //var client = new RestClient("https://localhost:44397");
                //var request = new RestRequest("api/categories/getbyid/" + source.Id, Method.GET);
                //var queryResult = client.Execute<CategoryActivityViewModel>(request).Data;
                //Category = queryResult;
            }
        }

        public void OnCreateCategory()
        {
            var content = new Dictionary<string, string>{
              { "Name", Category.Name },
              { "Description", Category.Description },
            };
            var data = RestApiUtils.Instance.Post("api/category/add", content);
            var a = 1;
        }
    }
}
