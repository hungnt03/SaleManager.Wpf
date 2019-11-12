using Caliburn.Micro;
using Newtonsoft.Json;
using SaleManager.Api.Models;
using SaleManager.Wpf.Inflastructors;
using SaleManager.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.ViewModels
{
    public class LoginViewModel:Screen
    {
        private readonly INavigationService navigationService;
        private string _username;
        private string _password;
        static HttpClient client = new HttpClient();
        public LoginViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Username = "hungnt.hut56@gmail.com";
            Password = "Root@123";
        }
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        //public bool CanLogin(string username, string password)
        //{
        //    return !String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password);
        //}

        public async void Login()
        {
            //var data = new Dictionary<string, string>{
            //  { "Email", this.Username },
            //  { "Password", this.Password },
            //};

            var logged = await RestApiUtils.Instance.Login(this.Username, this.Password);
            navigationService.NavigateToViewModel(typeof(MenuViewModel));
        }
    }
}
