using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;

namespace ForumApi.Domain.IServices
{
    public interface IAuth_Service
    {
        Task<User> Authenticate(string login, string password);
    }
}