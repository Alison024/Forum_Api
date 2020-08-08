using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class Post_Response : Base_Response
    {
        public Post_Response(bool success, string message,Post post) : base(success, message)
        {
            this.post = post;
        }
        public Post post{get;private set;}
        public Post_Response(Post post):this(true,string.Empty,post){}
        public Post_Response(string mes):this(false,mes,null){}
    }
}