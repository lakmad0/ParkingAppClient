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
    public class SlotApiServices
    {
        string url = "http://10.2.3.93:45455/api/Slots/";

        public async Task<bool> PutSlotAsync(string accessToken, Slot slot, string id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(slot);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(url + id, content);

            return response.IsSuccessStatusCode;
        }
    }
}
