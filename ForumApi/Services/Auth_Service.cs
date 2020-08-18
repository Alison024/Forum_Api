using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using ForumApi.Helpers;
using System.Linq;
using Microsoft.Extensions.Options;
using ForumApi.Extensions;
namespace ForumApi.Services
{
    public class Auth_Service : IAuth_Service
    {
        private readonly AppSettings appSettings;
        private readonly IUser_Repository user_Repository;
        public Auth_Service(IOptions<AppSettings> appSettings,  IUser_Repository user_Repository){
            this.appSettings = appSettings.Value;
            this.user_Repository = user_Repository;
        }
        public async Task<User> Authenticate(string email, string password)
        {
            password = Helper_MD5.GenerateMD5Hash(password);
            var customer = (await user_Repository.GetAllAsync())
                                .SingleOrDefault(usr => usr.Email == email && usr.Password == password);  
            if (customer == null)
                return null;

            customer.GenerateToken(appSettings.Secret, appSettings.ExpiresMinutes);

            return customer;
        }
    }
}