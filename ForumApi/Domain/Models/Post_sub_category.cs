using System.Collections.Generic;
using System.ComponentModel;
namespace ForumApi.Domain.Models
{
    public class Post_sub_category
    {
        public int Post_Id{get;set;}
        public int Sub_Category_Id{get;set;}
        public Post Post{get;set;}
        public Sub_category Sub_Categories{get;set;}
    }
}