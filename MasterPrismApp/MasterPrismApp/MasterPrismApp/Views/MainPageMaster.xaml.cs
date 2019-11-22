using MasterPrismApp.Models;
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
            Root.ChangedDetailPage(seleccionado);

            ((ListView)sender).SelectedItem = null;
        }
    }
}