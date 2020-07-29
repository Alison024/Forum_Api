using System.Collections.Generic;
namespace ForumApi.Domain.Models
{
    public class User_info
    {
        public int Id{get;set;}
        public int User_Rate{get;set;}
        public int Comments{get;set;}
        public int Answers{get;set;}
        public int Questions{get;set;}
        public User User {get;set;}
    }
}