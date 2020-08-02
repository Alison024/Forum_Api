using System.Collections.Generic;
using System;
namespace ForumApi.Domain.Models
{
    public class Post
    {
        public int Id{get;set;}
        public int Author_Id{get;set;}
        public int Paren_Post_Id{get;set;}
        public int Post_Type_Id{get;set;}
        public string Title{get;set;}
        public string Content{get;set;}
        public DateTime Date{get;set;}
        public int Post_Rate{get;set;}

        public User Author{get;set;}

        //public IList<Post> Posts{get;set;} = new List<Post>();
        public Post Parent_Post{get;set;}
        public IList<Post> Children_Posts{get;set;} = new List<Post>();
        public Post_type Post_Type{get;set;}
        public IList<Post_image> Post_Images{get;set;} = new List<Post_image>();
        public IList<Post_sub_category> Post_Sub_Categories{get;set;} = new List<Post_sub_category>();
    }
}