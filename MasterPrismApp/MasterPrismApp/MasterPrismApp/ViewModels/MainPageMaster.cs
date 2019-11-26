using MasterPrismApp.Models;
using MasterPrismApp.Views;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MasterPrismApp.ViewModels
{
    public class MainPageMasterViewModel : Prism.Mvvm.BindableBase
    {
        private ObservableCollection<MasterMenuItem> _DatosMenu;
        public ObservableCollection<MasterMenuItem> DatosMenu
        {
            get => _DatosMenu;
            set => SetProperty(ref _DatosMenu, value);
        }

        public MainPageMasterViewModel()
        {
            var lista = new List<MasterMenuItem>
            {
                new MasterMenuItem
                {
                    ExactPageName=nameof(MyPokemons),
                    Icon="ic_launcher.png",
                    Title="Pokedex"
                },
                new MasterMenuItem
                {
                    ExactPageName=nameof(MyPokemons),
                    Icon="ic_launcher.png",
                    Title="Mis pokemons"
                } ,
                new MasterMenuItem
                {
                    ExactPageName=nameof(MyPokemons),
                    Icon="ic_launcher.png",
                    Title="Pokedex"
                },
                new MasterMenuItem
                {
                    ExactPageName=nameof(MyPokemons),
                    Icon="ic_launcher.png",
                    Title="Mis pokemons"
                },
                new MasterMenuItem
                {
                    ExactPageName=nameof(MyPokemons),
                    Icon="ic_launcher.png",
                    Title="Pokedex"
                },
                new MasterMenuItem
                {
                    ExactPageName=nameof(MyPokemons),
                    Icon="ic_launcher.png",
                    Title="Mis pokemons"
                },
                new MasterMenuItem
                {
                    ExactPageName=nameof(MyPokemons),
                    Icon="ic_launcher.png",
                    Title="Pokedex"
                },
                new MasterMenuItem
                {
                    ExactPageName=nameof(MyPokemons),
                    Icon="ic_launcher.png",
                    Title="Mis pokemons"
                },
                new MasterMenuItem
                {
                    ExactPageName=nameof(MyPokemons),
                    Icon="ic_launcher.png",
                    Title="Pokedex"
                },
                new MasterMenuItem
                {
                    ExactPageName=nameof(MyPokemons),
                    Icon="ic_launcher.png",
                    Title="Mis pokemons"
                }
            };
            DatosMenu = new ObservableCollection<MasterMenuItem>(lista);
        }

    }
}
