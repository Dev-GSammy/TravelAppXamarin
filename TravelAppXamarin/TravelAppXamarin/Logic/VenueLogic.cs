using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelAppXamarin.Model;

namespace TravelAppXamarin.Logic
{
    public class VenueLogic
    {
        /*Truth be told, I don't yet understand what this means. I know we have already received the long and lat from the endpoint which
         * was then saved in the Helpers folder. We created a Model folder where the Logic class was defined and where the generateURL method is
         * located. We then created this folder called Logic where we initialized the class VenueLogic and tried to receive the response from 
         * the endpoint as a List. The method is receiving it as a list. It will then be deserialized into c# object. But I still don't get it.
         */

        public async static Task<List<Venues>> GetVenues(double latitude, double longitude)
        {
            List<Venues> venues = new List<Venues>();   

            var url = Venues.GenerateURL(latitude, longitude);
            /*
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url); 
                var json = await response.Content.ReadAsStringAsync();
            }*/

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                    {
                        { "Accept", "application/json" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
            }

            return venues;
        }
    }
} 
