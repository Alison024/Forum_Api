using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class Post_Image_Response : Base_Response
    {
        public Post_Image_Response(bool success, string message,Post_image post_Image) : base(success, message)
        {
            this.post_Image = post_Image;
        }
        public Post_image post_Image{get;private set;}
        public Post_Image_Response(Post_image post_Image):this(true,string.Empty,post_Image){}
        public Post_Image_Response(string mes):this(false,mes,null){}
    }
}