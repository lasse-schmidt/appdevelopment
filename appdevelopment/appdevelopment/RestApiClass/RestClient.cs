using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace appdevelopment.RestClient
{
    class RestClient<T>
    {

        private const string MainWebServiceUrl = "http://10.0.2.2:5000/";
        private const string LoginWebServiceUrl = "https://skoleapi.azurewebsites.net/api/Users/";
        public async Task<bool> CheckLogin(string email)
        {
            var httpClient = new HttpClient(new HttpClientHandler());
            var response = await httpClient.GetAsync(LoginWebServiceUrl + email);
            return response.IsSuccessStatusCode;
        }
    }
}