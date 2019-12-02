using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using YUGIOH_Master.Models;
using YUGIOH_Master.Patterns;
using YUGIOH_Master.Services;
using YUGIOH_Master.Views;

namespace YUGIOH_Master.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private AllCardsData _AllCardsDecks;

        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get => new Command(async () => await ExecuteLoadItemsCommand()); }
        public AllCardsData AllCardsDecks
        {
            set => SetProperty(ref _AllCardsDecks, value);
            get => _AllCardsDecks;
        }


        public ItemsViewModel()
        {
            Title = "All Cards";
            AllCardsDecks = null;

            MessagingCenter.Subscribe<MessaginCenterNames, Item>(new MessaginCenterNames(), "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Task.Run(() => { AllCardsDecks = Singleton.Cards; }).Wait();
                //Para mientras xd

                #region Codigo para convertir los Datos originales obtenidos del API

                //if (!Singleton.Instance.LocalJson.ExistsSavedJsonData())
                //{
                //    #region SavedCardsWithLinks
                //    IsBusy = true;

                //    var allCardsConverted = new AllCardsData();


                //    IsBusy = true;
                //    allCardsConverted.link_monster_cards = new System.Collections.Generic.List<card_data_sets>();
                //    foreach (var card in Singleton.Cards.link_monster_cards)
                //    {
                //        if (card.card_sets.Count > 0)
                //        {
                //            var carta = card;
                //            carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                //            carta.card.raritySelected = card.card_sets[0].rarity;
                //            carta.card.isCardInDeck = false;
                //            carta.card_sets = null;
                //            allCardsConverted.link_monster_cards.Add(carta);
                //        }
                //    }

                //    allCardsConverted.monster_cards = new System.Collections.Generic.List<card_data_sets>();
                //    foreach (var card in Singleton.Cards.monster_cards)
                //    {
                //        if (card.card_sets.Count > 0)
                //        {
                //            var carta = card;
                //            carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                //            carta.card.isCardInDeck = false;
                //            carta.card.raritySelected = card.card_sets[0].rarity;
                //            carta.card_sets = null;
                //            allCardsConverted.monster_cards.Add(carta);
                //        }
                //    }
                //    IsBusy = true;

                //    allCardsConverted.pendulum_monster_cards = new System.Collections.Generic.List<card_data_sets>();
                //    foreach (var card in Singleton.Cards.pendulum_monster_cards)
                //    {
                //        if (card.card_sets.Count > 0)
                //        {
                //            var carta = card;
                //            carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                //            carta.card.isCardInDeck = false;
                //            carta.card.raritySelected = card.card_sets[0].rarity;
                //            carta.card_sets = null;
                //            allCardsConverted.pendulum_monster_cards.Add(carta);
                //        }
                //    }


                //    allCardsConverted.ritual_monster_cards = new System.Collections.Generic.List<card_data_sets>();
                //    foreach (var card in Singleton.Cards.ritual_monster_cards)
                //    {
                //        if (card.card_sets.Count > 0)
                //        {
                //            var carta = card;
                //            carta.card.isCardInDeck = false;
                //            carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                //            carta.card.raritySelected = card.card_sets[0].rarity;
                //            carta.card_sets = null;
                //            allCardsConverted.ritual_monster_cards.Add(carta);
                //        }
                //    }

                //    IsBusy = true;

                //    allCardsConverted.spell_cards = new System.Collections.Generic.List<card_data_sets>();
                //    foreach (var card in Singleton.Cards.spell_cards)
                //    {
                //        if (card.card_sets.Count > 0)
                //        {
                //            var carta = card;
                //            carta.card.isCardInDeck = false;
                //            carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                //            carta.card.raritySelected = card.card_sets[0].rarity;
                //            carta.card_sets = null;
                //            allCardsConverted.spell_cards.Add(carta);
                //        }
                //    }


                //    allCardsConverted.synchro_monster_cards = new System.Collections.Generic.List<card_data_sets>();
                //    foreach (var card in Singleton.Cards.synchro_monster_cards)
                //    {
                //        if (card.card_sets.Count > 0)
                //        {
                //            var carta = card;
                //            carta.card.isCardInDeck = false;
                //            carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                //            carta.card.raritySelected = card.card_sets[0].rarity;
                //            carta.card_sets = null;
                //            allCardsConverted.synchro_monster_cards.Add(carta);
                //        }
                //    }

                //    IsBusy = true;

                //    allCardsConverted.trap_cards = new System.Collections.Generic.List<card_data_sets>();
                //    foreach (var card in Singleton.Cards.trap_cards)
                //    {
                //        if (card.card_sets.Count > 0)
                //        {
                //            var carta = card;
                //            carta.card.isCardInDeck = false;
                //            carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                //            carta.card.raritySelected = card.card_sets[0].rarity;
                //            carta.card_sets = null;
                //            allCardsConverted.trap_cards.Add(carta);
                //        }
                //    }


                //    allCardsConverted.xyz_monster_cards = new System.Collections.Generic.List<card_data_sets>();
                //    foreach (var card in Singleton.Cards.xyz_monster_cards)
                //    {
                //        if (card.card_sets.Count > 0)
                //        {
                //            var carta = card;
                //            carta.card.isCardInDeck = false;
                //            carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                //            carta.card.raritySelected = card.card_sets[0].rarity;
                //            carta.card_sets = null;
                //            allCardsConverted.xyz_monster_cards.Add(carta);
                //        }
                //    }

                //    #endregion

                //    IsBusy = true;

                //    AllCardsDecks = allCardsConverted;
                //    Singleton.Instance.SavedDatainJson_Singleton(AllCardsDecks);
                //}
                #endregion

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}