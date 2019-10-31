using Caliburn.Micro;
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

        public void Login(string username, string password)
        {
            navigationService.NavigateToViewModel(typeof(MenuViewModel));
        }
    }
}
