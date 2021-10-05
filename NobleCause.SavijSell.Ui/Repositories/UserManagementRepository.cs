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
        public async Task<string> LoginAsync(string email, string password)
        {
            var userLogin = new UserLogin
            {
                Email = email,
                Password = password
            };

            var token = await "https://localhost:44328/"
                     .AppendPathSegment("/api/token")
                     .PostJsonAsync(userLogin).ReceiveJson<string>();

            return token;

        }

        public async Task SignUp(string firstName, string lastName, string email,
                           string password, string userName,
                           string postalCode)
        {
            var userSignUp = new UserSignUp
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                UserName = userName,
                PostalCode = postalCode
            };

            await "https://localhost:44328/"
                   .AppendPathSegment("/api/Users")
                   .PostJsonAsync(userSignUp);
        }
    }
}
