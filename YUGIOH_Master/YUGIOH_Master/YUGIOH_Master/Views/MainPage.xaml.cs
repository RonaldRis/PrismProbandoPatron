using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using YUGIOH_Master.Models;

namespace YUGIOH_Master.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.AllCards, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int tipo)
        {
            if (!MenuPages.ContainsKey(tipo))
            {
                switch (tipo)
                {
                    case (int)MenuItemType.AllCards:
                        MenuPages.Add(tipo, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.MyCards:
                        MenuPages.Add(tipo, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[tipo];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}