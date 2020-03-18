using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyFace.Models.Database;
using MyFace.Repositories;

namespace MyFace.Helpers
{
    public interface IBasicAuthenticateHelper
    {
        bool HandleAuthenticate(HttpRequest request);
    }
    
    public class BasicAuthenticateHelper : IBasicAuthenticateHelper
    {
        private readonly IUsersRepo _usersRepo;
        private const string AUTH_HEADER_NAME = "Authorization";
        private const string BASIC_AUTH_NAME = "Basic";

        public BasicAuthenticateHelper(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }
        
        public bool HandleAuthenticate(HttpRequest request)
        {
            if (!request.Headers.ContainsKey(AUTH_HEADER_NAME))
            {
                return false;
            }

            User user = null;
            try
            {
                var authHeader = request.Headers[AUTH_HEADER_NAME];
                var authHeaderValue = authHeader[0];

                if (!authHeaderValue.StartsWith(BASIC_AUTH_NAME))
                {
                    return false;
                }

                var encodedValue = authHeaderValue.Substring(BASIC_AUTH_NAME.Length);
                var credentialBytes = Convert.FromBase64String(encodedValue);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] {':'}, 2);
                var username = credentials[0];
                var password = credentials[1];
                user = _usersRepo.Authenticate(username, password);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}