using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Services
{
    public class Notifier : INotifier
    {
        private readonly HttpClient _client;
        public Notifier(HttpClient client)
        {
            _client = client;
        }
        public async Task NotifyOtpFailure(string phoneNumber, string message)
        {
            var data = JsonConvert.SerializeObject(new { PhoneNumber = phoneNumber, ErrorMessage = message });
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/email/opt-failure", content);
            if (response.IsSuccessStatusCode)
            {

            }
            else
            {

            }
        }
    }
}
