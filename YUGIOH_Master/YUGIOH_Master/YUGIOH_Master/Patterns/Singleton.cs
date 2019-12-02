using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YUGIOH_Master.Models;
using YUGIOH_Master.Services;

namespace YUGIOH_Master.Patterns
{
    public class Singleton
    {
        #region Attributes

        private static Singleton _Instance;
        private JsonData _LocalJson;
        private static AllCardsData _cards;

        #endregion

        #region MyRegion

        public static Singleton Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Singleton();

                return _Instance;
            }
        }

        public static AllCardsData Cards
        {
            set
            {
                if (_cards == value)
                    return;

                _cards = value;
            }
            get { return _cards; }
        }


        public JsonData LocalJson
        {
            get { return this._LocalJson; }
        }

        #endregion

        #region Constructor

        public Singleton()
        {
            this._LocalJson = new JsonData();
        }


        public void SavedDatainJson_Singleton(AllCardsData cartasGuardar)
        {
            this.LocalJson.SaveData(cartasGuardar);
            Cards = cartasGuardar;
        }

        #endregion

        #region Methods

        public async Task VerifyCardsJson()
        {
            if (!this._LocalJson.ExistsSavedJsonData())
            {
                Cards = await this.LocalJson.ReadOriginalData();
            }
            else
            {
                Cards = await this._LocalJson.ReadSavedData();
            }
        }

        #endregion
    }
}
