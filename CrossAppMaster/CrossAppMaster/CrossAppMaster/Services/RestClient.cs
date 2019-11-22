using CrossAppMaster.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CrossAppMaster.Services
{
    public class RestClient
    {
        private static string url = "http://brotproject.somee.com/api/";
        public static bool isConnectedToInterned()  //Lo ideal seria mandar esto desde la app antes de usar el REST
        {
            var clientNet = new System.Net.Http.HttpClient();
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                return true;
            }

            return false;
        }

        public static async Task<string> GetAll<T>(String Controller)
        {

           
            if (isConnectedToInterned())
            {
                try
                {
                    var client = new RestSharp.RestClient("https://ronreiter-meme-generator.p.rapidapi.com/meme?font=Impact&font_size=50&meme=Condescending-Wonka&top=Top%20text&bottom=Bottom%20text");
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("x-rapidapi-host", "ronreiter-meme-generator.p.rapidapi.com");
                    request.AddHeader("x-rapidapi-key", "c3ac2531dfmsh910e1a1edfb36d6p17c487jsn26f75a8c3178");
                    IRestResponse response = client.Execute(request);
                    //var response = await cliente.GetAsync(url + Controller);
                    return response.Content;
                }
                catch (Exception e)
                {
                    return "This went wrong";
                }
            }
            return "No internet connection";

        }

        
    }
}
