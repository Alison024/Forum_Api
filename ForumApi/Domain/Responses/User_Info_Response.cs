using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class User_Info_Response : Base_Response
    {
        public User_Info_Response(bool success, string message,User_info user_Info) : base(success, message)
        {
            this.user_Info = user_Info;
        }
        public User_info user_Info{get;private set;}
        public User_Info_Response(User_info user_Info):this(true,string.Empty,user_Info){}
        public User_Info_Response(string mes):this(false,mes,null){}
    }
}