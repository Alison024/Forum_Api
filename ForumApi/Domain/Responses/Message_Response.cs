using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class Message_Response : Base_Response
    {
        public Message_Response(bool success, string message, Message message1) : base(success, message)
        {
            this.message = message1;
        }
        public Message message{get;private set;}
        public Message_Response(Message message):this(true,string.Empty,message){}
        public Message_Response(string mes):this(false,mes,null){}
    }
}