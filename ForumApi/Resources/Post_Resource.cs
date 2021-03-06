using System.Collections.Generic;
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
        public IList<Post_Image_Resource> Post_Images{get;set;}
         public IList<Post_Sub_Category_Resource> Post_Sub_Categories{get;set;}

    }
}