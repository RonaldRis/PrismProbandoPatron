using MasterPrismApp.Models;
using Prism.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterPrismApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {

        public MainPageMaster()
        {
            InitializeComponent();


        }

        //no se puede mandar a llamar MainPage ya que uso PRISM!!!
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (sender == null || e ==null)
                return;

            var seleccionado = e.SelectedItem as MasterMenuItem;
            MainPage Root = Application.Current.MainPage as MainPage;
            var pagethis = PageUtilities.GetCurrentPage(Application.Current.MainPage);
            try
            {
                MainPage mainpageprueba = (MainPage)PageUtilities.GetCurrentPage(Application.Current.MainPage);
                mainpageprueba.ChangedDetailPage(seleccionado);
            }
            catch (Exception) { }

            try
            {
                Root.ChangedDetailPage(seleccionado);
            }
            catch (Exception) { }

            ((ListView)sender).SelectedItem = null;
        }
    }
}