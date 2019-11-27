

namespace YUGIOH_Master.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class RestClient :IDisposable
    {
        string url = "https://yugioh-card-api.kaishiyoku.rocks/api/v1/";
        HttpClient client;

        public void Dispose()
        {
            client.Dispose();
        }

        public async Task<IEnumerable<T>> GetAll<T>(string tabla)
        {
            try
            {
                client = new HttpClient();
                var response = await client.GetAsync(url + tabla);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
                }
            }
            catch (Exception)
            {
                return default(IEnumerable<T>);
            }
            return default(IEnumerable<T>);
        }

        public async Task<T> GetElement<T>(string tabla)
        {
            try
            {
                client = new HttpClient();
                var response = await client.GetAsync(url + tabla);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
                }
            }
            catch (Exception)
            {
                return default(T);
            }
            return default(T);
        }
    }
}
