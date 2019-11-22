using Prism;
using Prism.Ioc;
using Prism.Modularity;
using PrismApp01.ViewModels;
using PrismApp01.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismApp01
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SecondPage, SecongPageVM>();
            containerRegistry.RegisterForNavigation<SecondPrismPage, SecondPrismPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismNavigationPage1, PrismNavigationPage1ViewModel>();
            containerRegistry.RegisterForNavigation<PrismMasterDetailPage1, PrismMasterDetailPage1ViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule()
            moduleCatalog.AddModule(PrismAppModule.PrismAppModuleModule);

        }
    }
}
