using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Essentials;
namespace TaskManager.Services
{
    public class AuthService : IAuthService
    {
        private readonly string AuthorKey = "TaskManager-By-TTA";
        private Account CurrentUser
        {
            get
            {
                var serializedAccount = SecureStorage.GetAsync(AuthorKey).ConfigureAwait(true).GetAwaiter().GetResult();
                return string.IsNullOrWhiteSpace(serializedAccount) ? null : Account.Deserialize(serializedAccount);
            }
        }

        public void DeleteCredentials()
        {
            if (CurrentUser != null)
            {
                SecureStorage.Remove(CurrentUser.Serialize());
            }
        }

        public string GetAccessToken()
        {
            return CurrentUser.Properties["AccessToken"];
        }

        public string GetPassword()
        {
            return CurrentUser.Properties["Password"];
        }

        public string GetUserName()
        {
            return CurrentUser.Properties["UserName"];
        }

        public async Task SaveCredentials(string userName, string password)
        {
            var account = new Account(userName, properties: new Dictionary<string, string> { { "Password", password } });
            await SecureStorage.SetAsync(account.Serialize(), AuthorKey);
        }

        public bool IsAuthorized()
        {
            return (CurrentUser != null && !string.IsNullOrWhiteSpace(GetPassword()));
        }

        public void SetPassword(string Password)
        {
            if (CurrentUser != null)
            {
                CurrentUser.Properties["Password"] = Password;
            }
        }
    }
}
