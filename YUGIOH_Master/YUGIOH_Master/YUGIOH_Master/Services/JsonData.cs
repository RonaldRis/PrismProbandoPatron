using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YUGIOH_Master.Models;
using YUGIOH_Master.Patterns;

namespace YUGIOH_Master.Services
{
    public class JsonData
    {
        private readonly string _Path;
        private readonly string _FilePath;

        public JsonData()
        {
            this._Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            this._FilePath = Path.Combine(this._Path, "YugiOhMaterCards.json");
        }
        public void SaveData(AllCardsData Cartas)
        {
            String result = Newtonsoft.Json.JsonConvert.SerializeObject(Cartas);

            using (var file = File.Open(this._FilePath, FileMode.Create, FileAccess.Write))

            using (var strm = new StreamWriter(file))
            {
                strm.Write(result);
                strm.Close();
            }
        }
        public async Task<AllCardsData> ReadSavedData()
        {
            using (var file = File.Open(this._FilePath, FileMode.Open, FileAccess.Read))

            using (var strm = new StreamReader(file))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<AllCardsData>( await strm.ReadToEndAsync());
            }
        }

        public async Task<AllCardsData> ReadOriginalData()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(JsonData)).Assembly;
                string resourceName = $"YUGIOH_Master.CardsData.json";
                Stream stream = assembly.GetManifestResourceStream(resourceName);

                using (var reader = new System.IO.StreamReader(stream))
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<AllCardsData>(await reader.ReadToEndAsync());
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public bool ExistsSavedJsonData()
        {
            return File.Exists(this._FilePath);
        }


    }
}
