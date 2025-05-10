using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace EasyAppointments.API
{
    public interface IAPIService
    {
        Task<string> PostAsync(object model, string aPiEndPoint);
        Task<string> PutAsync(object model, string aPiEndPoint);
        Task<string> DeleteAsync(string aPiEndPoint);
        Task<string> GetAsync(string aPiEndPoint);
        Task<string> GetByIdAsync(string aPiEndPoint);
        Task<(HttpStatusCode, string)> LoginAsync(object model, string aPiEndPoint);
    }
    public class APIService : IAPIService
    {
        string baseUrl = "https://localhost:7269/api/";
        public async Task<string> DeleteAsync(string aPiEndPoint)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(baseUrl + aPiEndPoint);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> GetAsync(string aPiEndPoint)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(baseUrl + aPiEndPoint);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> GetByIdAsync(string aPiEndPoint)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(baseUrl + aPiEndPoint);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<(HttpStatusCode, string)> LoginAsync(object model, string aPiEndPoint)
        {
            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(baseUrl + aPiEndPoint, content);
                var token = await response.Content.ReadAsStringAsync();
                return (response.StatusCode, token);
            }
        }

        public async Task<string> PostAsync(object model, string aPiEndPoint)
        {
            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(baseUrl + aPiEndPoint, content);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> PutAsync(object model, string aPiEndPoint)
        {
            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(baseUrl + aPiEndPoint, content);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
