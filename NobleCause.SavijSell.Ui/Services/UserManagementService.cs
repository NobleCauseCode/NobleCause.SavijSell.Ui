using NobleCause.SavijSell.Ui.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;


namespace NobleCause.SavijSell.Ui.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserManagementRepository _userManagementRepository;

        public UserManagementService(IUserManagementRepository userManagementRepository)
        {
            _userManagementRepository = userManagementRepository;
        }

        public async Task SignUp(string firstName, string lastName, 
                           string email, string password, string userName, 
                           string postalCode)
        {
            var encryptedPassword = Crypto.HashPassword(password);

            await _userManagementRepository.SignUp(firstName, lastName, email, 
                                                   encryptedPassword,
                                                   userName, postalCode);
        }
    }
}
