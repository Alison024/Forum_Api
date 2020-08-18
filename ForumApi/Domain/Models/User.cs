using System.Collections.Generic;
using System;
namespace ForumApi.Domain.Models
{
    public class User
    {
        public int Id{get;set;}
        public int Avatar_Id{get;set;}
        public int User_Info_Id{get;set;}
        public string Name{get;set;}
        public string Surname{get;set;}
        public string User_Name{get;set;}
        public string Email{get;set;}
        public string Password{get;set;}
        public string Phone_Number{get;set;}
        public DateTime Birthday{get;set;}
        public string Token{get;set;}
        public Avatar_image Avatar_Image{get;set;}

        //public IList<User_info> User_Info{get;set;} = new List<User_info>();
        public User_info User_Info{get;set;}
        public IList<Message> Sended_Messages{get;set;} = new List<Message>();
        //public Message Received_Message{get;set;}
        public IList<Message> Received_Messages{get;set;} = new List<Message>();
        public IList<User_role> User_Roles{get;set;} = new List<User_role>();
        public IList<Post> Posts{get;set;} = new List<Post>();

    }
}