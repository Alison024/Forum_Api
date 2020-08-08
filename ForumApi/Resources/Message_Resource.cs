using System;

namespace ForumApi.Resources
{
    public class Message_Resource
    {
        public int Id{get;set;}
        public int Sender_Id{get;set;}
        public int Receiver_Id{get;set;}
        public DateTime Send_Time{get;set;}
        public string Message_Content{get;set;}
        public int Status_Id{get;set;}
    }
}