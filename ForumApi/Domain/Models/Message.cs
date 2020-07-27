using System.Collections.Generic;
using System;
namespace ForumApi.Domain.Models
{
    public class Message
    {
        public int Id{get;set;}
        public int Sender_Id{get;set;}
        public int Receiver_Id{get;set;}
        public DateTime Send_Time{get;set;}
        public string Content{get;set;}
        public int Status_Id{get;set;}
        public Status Status{get;set;}
        public User Senders{get;set;}
        //public User Senders{get;set;}
        public User Receivers{get;set;}
        //public User Receivers{get;set;}
    }
}