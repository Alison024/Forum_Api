using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class Image_Response : Base_Response
    {
        public Image_Response(bool success, string message,Image Image) : base(success, message)
        {
            this.Image = Image;
        }
        public Image Image{get;private set;}
        public Image_Response(Image Image):this(true,string.Empty,Image){}
        public Image_Response(string mes):this(false,mes,null){}
    }
}