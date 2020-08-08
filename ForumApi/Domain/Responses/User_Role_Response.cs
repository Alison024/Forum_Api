using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class User_Role_Response : Base_Response
    {
        public User_Role_Response(bool success, string message,User_role user_Role) : base(success, message)
        {
            this.user_Role = user_Role;
        }
        public User_role user_Role{get;private set;}
        public User_Role_Response(User_role user_Role):this(true,string.Empty,user_Role){}
        public User_Role_Response(string mes):this(false,mes,null){}
    }
}