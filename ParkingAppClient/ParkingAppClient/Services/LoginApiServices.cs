using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParkingAppClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAppClient.Services
{
    public class LoginApiServices
    {
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://10.2.4.139:45456/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://10.2.4.139:45456/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

            var accessToken = jwtDynamic.Value<string>("access_token"); 

            Debug.WriteLine(content);

            return accessToken;
        }
    }
}
