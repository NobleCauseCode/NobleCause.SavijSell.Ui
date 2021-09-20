using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Repositories
{
    public interface IUserManagementRepository
    {
        Task SignUp(string firstName, string lastName, string email, 
                    string encryptedPassword, string userName, string postalCode);
    }
}
