using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;

namespace PrismApp01.ViewModels
{
    class SecongPageVM : ViewModelBase
    {
        public SecongPageVM(INavigationService navigationService) : base(navigationService)
        {
            Title = "Second Page";
        }




    }
}
