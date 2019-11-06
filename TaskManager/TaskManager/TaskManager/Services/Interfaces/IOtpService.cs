
namespace TaskManager.Services
{
    public interface IOtpService
    {
        bool SendOtp(string phoneNumber);
    }
}
