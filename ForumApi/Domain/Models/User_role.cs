using System.Collections.Generic;
namespace ForumApi.Domain.Models
{
    public class User_role
    {
        public int Role_Id{get;set;}
        public Role Role{get;set;}
        public int User_Id{get;set;}
        public User User{get;set;}
    }
}