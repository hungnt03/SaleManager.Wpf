using Caliburn.Micro;
using System.ComponentModel;

namespace SaleManager.Wpf.ViewModels.Activity
{
    public abstract class ActivityBaseViewModel : PropertyChangedBase
    {
        public abstract string Title { get; }
    }
}