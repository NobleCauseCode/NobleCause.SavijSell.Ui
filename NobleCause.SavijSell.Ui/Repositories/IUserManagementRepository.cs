using NobleCause.SavijSell.Ui.Models;
using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Repositories
{
    public interface IUserManagementRepository
    {
        Task SignUp(string firstName, string lastName, string email, 
                    string encryptedPassword, string userName, string postalCode);
        Task<TokenResponse> LoginAsync(string email, string password);
        Task<int> GetUserIdByVerification(string verificationData);
    }
}
