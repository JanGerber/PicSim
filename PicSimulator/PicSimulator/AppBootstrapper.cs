using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using PicSimulator.ViewModels;

namespace PicSimulator
{
    class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper() //Einstellungen des Caliburn Framework
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
