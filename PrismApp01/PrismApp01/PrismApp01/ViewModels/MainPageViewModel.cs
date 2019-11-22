using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismApp01.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        //Atributos
        private DelegateCommand _delegateCommand;

        ///Atributos
        ///
        private string _nombre;
        private string _apellido;

        //Propiedades
        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }
        public string Apellido
        {
            get => _apellido;
            set => SetProperty(ref _apellido, value);
        }

        //Commands
        public DelegateCommand SendCommand => _delegateCommand ?? (_delegateCommand= new DelegateCommand(Enviar));

        private async void Enviar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                await App.Current.MainPage.DisplayAlert("Error", "El nombre no puede ir vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                await App.Current.MainPage.DisplayAlert("Error", "El apellido no puede ir vacio", "Ok");
                return;
            }
            //Creo los parametros
            INavigationParameters parametros = new NavigationParameters();
            parametros.Add("Nombre", Nombre);
            parametros.Add("Apellido", Apellido);
            await NavigationService.NavigateAsync(nameof(PrismApp01.Views.SecondPrismPage), parametros);

            Nombre = string.Empty;
            Apellido = string.Empty;
        }

        //Constructor
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }


        

    }
}
