using System.Collections.Generic;
namespace ForumApi.Domain.Models
{
    public class Image
    {
        public int Id{get;set;}
        public string File_Name{get;set;}
        public byte[] Image_Data{get;set;}
        public string Image_Url{get;set;}
        public IList<Post_image> Post_Images{get;set;} = new List<Post_image>();
    }
}