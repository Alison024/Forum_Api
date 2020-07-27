using System.Collections.Generic;
namespace ForumApi.Domain.Models
{
    public class Role
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public IList<User_role> User_Roles{get;set;} = new List<User_role>();
    }
}