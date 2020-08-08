using System;

namespace ForumApi.Resources
{
    public class Post_Resource
    {
        public int Id{get;set;}
        public int Author_Id{get;set;}
        public int Paren_Post_Id{get;set;}
        public int Post_Type_Id{get;set;}
        public string Title{get;set;}
        public string Post_Content{get;set;}
        public DateTime Date{get;set;}
        public int Post_Rate{get;set;}
    }
}