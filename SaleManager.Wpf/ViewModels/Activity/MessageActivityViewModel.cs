using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.ViewModels.Activity
{
    public class MessageActivityViewModel : ActivityBaseViewModel
    {
        public MessageActivityViewModel(string message)
        {
            Message = message;
        }

        public override string Title => "Message";
        public string Message { get; }
    }
}
