using Caliburn.Micro;
using SaleManager.Wpf.ViewModels;
using SaleManager.Wpf.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SaleManager.Wpf
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Instance(container);

            container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            container
               .PerRequest<ShellViewModel>()
               .PerRequest<MenuViewModel>()
               .PerRequest<LoginViewModel>()
               .PerRequest<CategoryViewModel>()
               .PerRequest<CategoryDetailViewModel>()
               .PerRequest<ExecuteViewModel>();
               //.PerRequest<BindingsViewModel>()
               //.PerRequest<ActionsViewModel>()
               //.PerRequest<CoroutineViewModel>()
               //.PerRequest<EventAggregationViewModel>()
               //.PerRequest<DesignTimeViewModel>()
               //.PerRequest<ConductorViewModel>()
               //.PerRequest<BubblingViewModel>()
               //.PerRequest<NavigationSourceViewModel>()
               //.PerRequest<NavigationTargetViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.Exception.Message, "An error as occurred", MessageBoxButton.OK);
        }
    }
}
