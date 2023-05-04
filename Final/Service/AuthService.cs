using Service.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthService
    {
        APICaller api = new APICaller();

        public async Task<AuthResponseModel> SignUp(string username, string password)
        {
            string hash = Utilities.HashUtil.HashPassword(password);
            var response = await api.Signup(username, hash);
            return response ?? new AuthResponseModel() { Success = false, Id = ""};
        }

        public async Task<AuthResponseModel> Login(string username, string password)
        {
            string hash = Utilities.HashUtil.HashPassword(password);
            var response = await api.Login(username, hash);
            return response ?? new AuthResponseModel() { Success = false };
        }
    }
}
