using NobleCause.SavijSell.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace NobleCause.SavijSell.Ui.Repositories
{
    public class UserManagementRepository : IUserManagementRepository
    {
        public async Task SignUp(string firstName, string lastName, string email, 
                           string encryptedPassword, string userName, 
                           string postalCode)
        {
            var userSignUp = new UserSignUp
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = encryptedPassword,
                UserName = userName,
                PostalCode = postalCode
            };

            await "https://localhost:44328/"
                   .AppendPathSegment("/api/Users")
                   .PostJsonAsync(userSignUp);
        }
    }
}
