using Caliburn.Micro;
using RestSharp;
using SaleManager.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.ViewModels
{
    public class LoginViewModel:Screen
    {
        private readonly INavigationService navigationService;
        private string _username;
        private string _password;
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

        public void Login()
        {
            var client = new RestClient("https://localhost:44312/");
            var request = new RestRequest("api/user/login", Method.POST);
            request.AddParameter("Email", Username);
            request.AddParameter("Password", Password);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            var queryResult = client.Execute<List<TokenModel>>(request).Data;
            
            navigationService.NavigateToViewModel(typeof(MenuViewModel));
        }
    }
}
