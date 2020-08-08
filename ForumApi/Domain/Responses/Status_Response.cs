using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class Status_Response : Base_Response
    {
        public Status_Response(bool success, string message,Status status) : base(success, message)
        {
            this.status = status;
        }
        public Status status{get;private set;}
        public Status_Response(Status status):this(true,string.Empty,status){}
        public Status_Response(string mes):this(false,mes,null){}
    }
}