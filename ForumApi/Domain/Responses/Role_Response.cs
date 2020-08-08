using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class Role_Response : Base_Response
    {
        public Role_Response(bool success, string message,Role role) : base(success, message)
        {
            this.role = role;
        }
        public Role role{get;private set;}
        public Role_Response(Role role):this(true,string.Empty,role){}
        public Role_Response(string mes):this(false,mes,null){}
    }
}