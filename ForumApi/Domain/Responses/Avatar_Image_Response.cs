using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class Avatar_Image_Response : Base_Response
    {
        
        public Avatar_Image_Response(bool success, string message,Avatar_image Avatar_Image) : base(success, message)
        {
            this.Avatar_Image = Avatar_Image;
        }
        public Avatar_image Avatar_Image{get;private set;}
        public Avatar_Image_Response(Avatar_image Avatar_Image):this(true,string.Empty,Avatar_Image){}
        public Avatar_Image_Response(string mes):this(false,mes,null){}
    }
}