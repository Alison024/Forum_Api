using System.Collections.Generic;
namespace ForumApi.Domain.Models
{
    public class User_role
    {
        public int Role_id{get;set;}
        public Role Role{get;set;}
        public int User_id{get;set;}
        public User Users{get;set;}
    }
}