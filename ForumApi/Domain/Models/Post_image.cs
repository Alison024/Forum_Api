using System.Collections.Generic;
namespace ForumApi.Domain.Models
{
    public class Post_image
    {
        public int Image_Id{get;set;}
        public int Post_Id{get;set;}
        public Image Image{get;set;}
        public Post Post{get;set;}
    }
}