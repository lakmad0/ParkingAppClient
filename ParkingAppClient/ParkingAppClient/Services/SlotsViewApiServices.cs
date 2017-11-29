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
    public class SlotsViewApiServices
    {
        string url = "http://10.2.3.93:45455/api/SlotsView/";

        public async Task<List<SlotsView>> GetSlotsViewsAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetStringAsync(url);

            var slotsViews = JsonConvert.DeserializeObject<List<SlotsView>>(response);

            return slotsViews;
        }

        public async Task<SlotsView> GetSlotsViewByIdAsync(string accessToken, int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetStringAsync(url + id.ToString());

            var slotsView = JsonConvert.DeserializeObject<SlotsView>(response);

            return slotsView;
        }
    }
}
