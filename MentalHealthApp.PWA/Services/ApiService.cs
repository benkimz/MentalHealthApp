using MentalHealthApp.PWA.Models;
using MentalHealthApp.PWA.Services.Interfaces;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace MentalHealthApp.PWA.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse?> SignInUser(string email, string password)
        {
            try
            {
                var response = await _httpClient.PostAsync($"login?email={email}&password={password}", JsonRequestBody(new { Email = email, Password = password }));
                return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<LoginResponse?>() : null; 
            }
            catch { return null; }
        }

        public async Task<SignUpResponse?> SignUpUser(string userName, string firstName, string lastName, string phoneNumber, string email, string password)
        {
            try
            {
                var response = await _httpClient.PostAsync($"register?username={userName}&first_name={firstName}&last_name={lastName}&phone_number={phoneNumber}&email={email}&password={password}", JsonRequestBody(new { Username = userName, First_name = firstName, Last_name = lastName, Phone_number = phoneNumber, Email = email, Password = password })); 
                return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<SignUpResponse?>() : null;
            }
            catch { return null; }
        }

        public async Task<ApiAppUser?> GetAppUser(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync("user");
                return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<ApiAppUser?>() : null;
            }
            catch { return null; }
        }

        private StringContent? JsonRequestBody<T>(T data)
        {
            return new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        }

        private void Dump<T>(T data)
        {
            Console.WriteLine(data);
            //f266631537e6f671b0f102fbdbafff4cad8b59ad2879f906d151399b1e3a9934
        }
    }
}
