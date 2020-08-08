namespace ForumApi.Domain.Responses
{
    public class Base_Response
    {
        public bool IsSuccess{get;protected set;}
        public string Message{get;protected set;}
        public Base_Response(bool success,string message){
            IsSuccess = success;
            Message = message;
        }
    }
}