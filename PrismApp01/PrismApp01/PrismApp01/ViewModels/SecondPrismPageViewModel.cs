using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismApp01.ViewModels
{
	public class SecondPrismPageViewModel : BindableBase, INavigationAware
	{

        ///Atributos
        ///
        private string _nombre;
        private string _apellido;
        private string _title;
        

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
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public SecondPrismPageViewModel()
        {
            Title = "Second Page here we go";
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            string data;
            parameters.TryGetValue<string>("Nombre",out data);
            Nombre = data;
            parameters.TryGetValue<string>("Apellido",out data);
            Apellido = data;
        }
    }
}
