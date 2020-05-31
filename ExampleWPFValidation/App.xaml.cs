using CommonServiceLocator;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using ExampleWPFValidation.Views;

namespace ExampleWPFValidation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
