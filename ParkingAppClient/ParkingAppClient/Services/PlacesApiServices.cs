using Newtonsoft.Json;
using ParkingAppClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAppClient.Services
{
    public class PlacesApiServices
    {
        public async Task<List<Place>> GetPlacesAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetStringAsync("http://10.2.4.139:45456/api/Places");

            var places = JsonConvert.DeserializeObject<List<Place>>(response);

            return places;
        }

        public async Task<Place> GetPlaceByIdAsync(string accessToken, int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetStringAsync("http://10.2.4.139:45456/api/Places/"+id.ToString());

            var place = JsonConvert.DeserializeObject<Place>(response);

            return place;
        }

        public async Task<bool> PostPlaceAsync(string accessToken, Place place)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(place);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://10.2.4.139:45456/api/Places", content);

            return response.IsSuccessStatusCode;
        }       
    }
}
