using System.Collections.Generic;
namespace ForumApi.Domain.Models
{
    public class Sub_category
    {
        public int Id{get;set;}
        public string Titile{get;set;}
        public string Description{get;set;}
        public int Category_Id{get;set;}
        public Category Category{get;set;}
        public IList<Post_sub_category> Post_Sub_Categories{get;set;} = new List<Post_sub_category>();
    }
}