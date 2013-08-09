using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommonServiceLocator.NinjectAdapter;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace ViewFirstComposition
{
    public class Bootstrapper
    {
        public void Run()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Top200ViewModel>()
                  .ToSelf()
                  .InSingletonScope();

            var sl = new NinjectServiceLocator(kernel);
            ServiceLocator.SetLocatorProvider(() => sl);

            var shell = Application.Current.MainWindow = kernel.Get<MainWindow>();
            shell.Show();
        }
    }
}
