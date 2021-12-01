using appdevelopment.RestClient;
using System;
using System.Collections.Generic;
using System.Text;
using appdevelopment.Models;
using System.Threading.Tasks;

namespace appdevelopment.Services
{
    class LoginService
    {
        RestClient<User> restClient = new RestClient<User>();
        public async Task<bool> CheckLoginIfExists(string email)
        {
            var check = await restClient.CheckLogin(email);
            return check;
        }
    }
}
