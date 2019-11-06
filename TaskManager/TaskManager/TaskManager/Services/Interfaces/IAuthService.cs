using System.Threading.Tasks;

namespace TaskManager.Services
{
    public interface IAuthService
    {
        Task SaveCredentials(string userName, string password);
        void DeleteCredentials();    
        void SetPassword(string Password);    
        string GetUserName();    
        string GetPassword();    
        string GetAccessToken();
        bool IsAuthorized();
    }
}
