using System.Threading.Tasks;

namespace TaskManager.Services
{
    public interface INotifier
    {
        Task NotifyOtpFailure(string phoneNumber, string message);
    }
}
