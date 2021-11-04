using NobleCause.SavijSell.Ui.Models;
using NobleCause.SavijSell.Ui.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserManagementRepository _userManagementRepository;

        public UserManagementService(IUserManagementRepository userManagementRepository)
        {
            _userManagementRepository = userManagementRepository;
        }

        public async Task<TokenResponse> LoginAsync(string email, string password)
        {
            return await _userManagementRepository.LoginAsync(email, password);
        }

        public async Task SignUp(string firstName, string lastName, 
                           string email, string password, string userName, 
                           string postalCode)
        {            
            await _userManagementRepository.SignUp(firstName, lastName, email, 
                                                   password,
                                                   userName, postalCode);
        }
    }
}
