using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class Post_Type_Response : Base_Response
    {
        public Post_Type_Response(bool success, string message,Post_type post_Type) : base(success, message)
        {
            this.post_Type = post_Type;
        }
        public Post_type post_Type{get;private set;}
        public Post_Type_Response(Post_type post_Type):this(true,string.Empty,post_Type){}
        public Post_Type_Response(string mes):this(false,mes,null){}
    }
}