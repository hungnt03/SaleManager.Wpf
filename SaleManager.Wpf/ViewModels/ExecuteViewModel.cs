using Caliburn.Micro;
using SaleManager.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.ViewModels
{
    public class ExecuteViewModel : Screen
    {
        private bool safe;

        public bool Safe
        {
            get { return safe; }
            set { Set(ref safe, value); }
        }

        public void StartBackgroundWork()
        {
            Task.Factory.StartNew(BackgroundWork);
        }

        private void BackgroundWork()
        {
            if (Safe)
                SafeBackgroundWork();
            else
                UnsafeBackgroundWork();
        }

        private void SafeBackgroundWork()
        {
            //Execute.OnUIThreadAsync(UpdateView);
        }

        private void UnsafeBackgroundWork()
        {
            UpdateView();
        }

        private Task UpdateView()
        {
            var view = (ExecuteView)GetView();

            view.UpdateView();

            return Task.CompletedTask;
        }
    }
}
