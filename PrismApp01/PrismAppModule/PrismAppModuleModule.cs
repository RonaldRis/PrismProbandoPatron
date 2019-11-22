using Prism.Ioc;
using Prism.Modularity;
using PrismAppModule.Views;
using PrismAppModule.ViewModels;
using System.Collections.ObjectModel;

namespace PrismAppModule
{
    public class PrismAppModuleModule : IModule,IModuleInfo
    {
        public Collection<string> DependsOn { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public InitializationMode InitializationMode { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string ModuleName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string ModuleType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Ref { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ModuleState State { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}
