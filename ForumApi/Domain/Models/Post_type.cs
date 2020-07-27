using System.Collections.Generic;
namespace ForumApi.Domain.Models
{
    public class Post_type
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public IList<Post> Posts{get;set;} = new List<Post>();
    }
}