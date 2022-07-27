using NobleCause.SavijSell.Ui.Models;
using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Services
{
    public interface IUserManagementService
    {
        Task SignUp(string firstName, string lastName, string email, 
                    string password, string userName, string postalCode);
        Task<TokenResponse> LoginAsync(string email, string password);
        Task<bool> VerifyEmail(string verificationData);
    }
}
