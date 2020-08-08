using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class User_Response : Base_Response
    {
        public User_Response(bool success, string message,User user) : base(success, message)
        {
            this.user = user;
        }
        public User user{get;private set;}
        public User_Response(User user):this(true,string.Empty,user){}
        public User_Response(string mes):this(false,mes,null){}
    }
}