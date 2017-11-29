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
        string url = "http://10.2.3.93:45455/api/Places/";

        public async Task<List<Place>> GetPlacesAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetStringAsync(url);

            var places = JsonConvert.DeserializeObject<List<Place>>(response);

            return places;
        }

        public async Task<Place> GetPlaceByIdAsync(string accessToken, int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetStringAsync(url + id.ToString());

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

            var response = await client.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutPlaceAsync(string accessToken, Place place)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(place);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(url + place.Id, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePlaceAsync(string accessToken, string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.DeleteAsync(url + id);

            return response.IsSuccessStatusCode;
        }
    }
}
