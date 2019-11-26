using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterPrismApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllPokemonsPage : ContentPage
	{
		public AllPokemonsPage ()
		{
			InitializeComponent ();
		}

        private void MenuItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}