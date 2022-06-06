using Newtonsoft.Json;
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

        /// <summary>
        /// The following lines of code will be commented out. because I want to use a set of new url from 
        /// a website called nomiatim. I pray it works.
        /// </summary>

        #region HttpPost
        /*public const string API_KEY = "fsq3l+IjJmALewbrD//AmkdoFys1EDhryOXVcfVoeDwoEI8=";
        public async static Task<List<Venues>> GetVenues(double latitude, double longitude)
        {
            List<Venues> venues = new List<Venues>();   
            var url = Venues.GenerateURL(latitude, longitude);
            ///////
            ///
            ///////
            var client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", API_KEY);
            /*var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
        {
        { "Accept", "application/json" },
        { "Authorization", API_KEY },
        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            /////
            /////
            ///////
            /*using (HttpClient client = new HttpClient()) 
            {
                var response = await client.GetAsync(url); 
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }


            return venues;
        }*/
        #endregion

        /// <summary>
        /// The following lines of code could help when trying to get a response that predictionkey and contenttype.
        /*
         private async void MakePredictionAsync(string filename)
        {
            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/d8b32c96-155d-4a73-9be1-f2a59da5364a/classify/iterations/Iteration1/image";
        string predictionKey = "7b80e3a48c904b34803048bf20b0ad8d";
        string contentType = "application/octet-stream";
        var file = File.ReadAllBytes(filename);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Prediction-Key", predictionKey);
                using (var content = new ByteArrayContent(file))
                {
                    //the namespace system.Net.http was added
                    try
                    {
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                        var response = await client.PostAsync(url, content);

    //we downloaded the Nuget package Newtonsoft.json
    var responseString = await response.Content.ReadAsStringAsync();

    List<Prediction> predictions = (JsonConvert.DeserializeObject<CustomVision>(responseString).predictions);
    predictionsListView.ItemsSource = predictions;
                    }
                    catch
{
    MessageBox.Show("Unable to connect to internet. Please check your network and try again.");
    Close();
}
                }
            }
        }*/
        
        public async static Task<List<VenueRoot>> GetVenues()
        {
            List<VenueRoot> address = new List<VenueRoot>();
            var url = VenueRoot.GenerateURL();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                ///You wouldn't believe that it was copilot that figured out this next line for me. I hope it works.
                var result = JsonConvert.DeserializeObject<List<VenueRoot>>(json); // It worked. Yayyyyyyyy
                address = result;
            }
            Console.WriteLine("Address of the listview has been gotten");
            return address ;
        }
    }
} 
