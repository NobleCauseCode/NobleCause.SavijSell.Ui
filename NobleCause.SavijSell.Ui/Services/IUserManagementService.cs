using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Services
{
    public interface IUserManagementService
    {
        Task SignUp(string firstName, string lastName, string email, 
                    string password, string userName, string postalCode);
        Task<string> LoginAsync(string email, string password);
    }
}
