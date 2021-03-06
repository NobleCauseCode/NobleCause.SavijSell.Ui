using NobleCause.SavijSell.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System.Net;

namespace NobleCause.SavijSell.Ui.Repositories
{
    public class UserManagementRepository : IUserManagementRepository
    {
        public async Task<TokenResponse> LoginAsync(string email, string password)
        {
            var userLogin = new UserLogin
            {
                Email = email,
                Password = password
            };

            return await "https://localhost:44328/"
                     .AppendPathSegment("/api/token")
                     .PostJsonAsync(userLogin).ReceiveJson<TokenResponse>();
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

        public async Task<int> GetUserIdByVerification(string verificationData)
        {
            var verifyEmailResponse = await "https://localhost:44328/"
                     .AppendPathSegment($"/api/Users/VerifyEmail/{verificationData}")
                     .AllowHttpStatus(HttpStatusCode.OK, HttpStatusCode.NotFound)
                     .GetJsonAsync<VerifyEmailResponse>();
            if(verifyEmailResponse == null)
            {
                return -1;
            }
            return verifyEmailResponse.UserId;
        }
    }
}
