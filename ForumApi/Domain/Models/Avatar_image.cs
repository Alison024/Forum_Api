using System.Collections.Generic;
namespace ForumApi.Domain.Models
{
    public class Avatar_image
    {
        public int Id{get;set;}
        public string File_name{get;set;}
        public byte[] Image_Data{get;set;}
        public string Image_Url{get;set;}
        public IList<User> Users{get;set;} = new List<User>();
    }
}