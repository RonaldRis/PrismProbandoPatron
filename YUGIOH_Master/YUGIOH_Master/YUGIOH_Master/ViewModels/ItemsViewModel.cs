using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using YUGIOH_Master.Models;
using YUGIOH_Master.Services;
using YUGIOH_Master.Views;

namespace YUGIOH_Master.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private AllCardsData _AllCardsDecks;

        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public AllCardsData AllCardsDecks
        {
            set => SetProperty(ref _AllCardsDecks, value);
            get => _AllCardsDecks;
        }
        public ItemsViewModel()
        {
            Title = "All Cards";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


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
                Items.Clear();
                using (var cliente = new RestClient())
                {
                    AllCardsDecks = await cliente.GetElement<AllCardsData>(YugiOhAPI.Cards);
                }


                var allCardsConverted = new AllCardsData();


                allCardsConverted.link_monster_cards = new System.Collections.Generic.List<card_data_sets>();
                foreach (var card in AllCardsDecks.link_monster_cards)
                {
                    if (card.card_sets.Count>0)
                    {
                        var carta = card;
                        carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                        carta.card.raritySelected = card.card_sets[0].rarity;
                        allCardsConverted.link_monster_cards.Add(carta);
                    }
                }

                allCardsConverted.monster_cards = new System.Collections.Generic.List<card_data_sets>();
                foreach (var card in AllCardsDecks.monster_cards)
                {
                    if (card.card_sets.Count > 0)
                    {
                        var carta = card;
                        carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                        carta.card.raritySelected = card.card_sets[0].rarity;
                        allCardsConverted.monster_cards.Add(carta);
                    }
                }

                allCardsConverted.pendulum_monster_cards = new System.Collections.Generic.List<card_data_sets>();
                foreach (var card in AllCardsDecks.pendulum_monster_cards)
                {
                    if (card.card_sets.Count > 0)
                    {
                        var carta = card;
                        carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                        carta.card.raritySelected = card.card_sets[0].rarity;
                        allCardsConverted.pendulum_monster_cards.Add(carta);
                    }
                }


                allCardsConverted.ritual_monster_cards = new System.Collections.Generic.List<card_data_sets>();
                foreach (var card in AllCardsDecks.ritual_monster_cards)
                {
                    if (card.card_sets.Count > 0)
                    {
                        var carta = card;
                        carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                        carta.card.raritySelected = card.card_sets[0].rarity;
                        allCardsConverted.ritual_monster_cards.Add(carta);
                    }
                }


                allCardsConverted.spell_cards = new System.Collections.Generic.List<card_data_sets>();
                foreach (var card in AllCardsDecks.spell_cards)
                {
                    if (card.card_sets.Count > 0)
                    {
                        var carta = card;
                        carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                        carta.card.raritySelected = card.card_sets[0].rarity;
                        allCardsConverted.spell_cards.Add(carta);
                    }
                }


                allCardsConverted.synchro_monster_cards = new System.Collections.Generic.List<card_data_sets>();
                foreach (var card in AllCardsDecks.synchro_monster_cards)
                {
                    if (card.card_sets.Count > 0)
                    {
                        var carta = card;
                        carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                        carta.card.raritySelected = card.card_sets[0].rarity;
                        allCardsConverted.synchro_monster_cards.Add(carta);
                    }
                }


                allCardsConverted.trap_cards = new System.Collections.Generic.List<card_data_sets>();
                foreach (var card in AllCardsDecks.trap_cards)
                {
                    if (card.card_sets.Count > 0)
                    {
                        var carta = card;
                        carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                        carta.card.raritySelected = card.card_sets[0].rarity;
                        allCardsConverted.trap_cards.Add(carta);
                    }
                }


                allCardsConverted.xyz_monster_cards = new System.Collections.Generic.List<card_data_sets>();
                foreach (var card in AllCardsDecks.xyz_monster_cards)
                {
                    if (card.card_sets.Count > 0)
                    {
                        var carta = card;
                        carta.card.imageSelected = $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card.card_sets[0].identifier}/image";
                        carta.card.raritySelected = card.card_sets[0].rarity;
                        allCardsConverted.xyz_monster_cards.Add(carta);
                    }
                }

                AllCardsDecks = allCardsConverted;


                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
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