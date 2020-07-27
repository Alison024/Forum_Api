using System.Collections.Generic;
namespace ForumApi.Domain.Models
{
    public class Category
    {
        public int Id{get;set;}
        public string Title{get;set;}
        public string Description{get;set;}
        public IList<Sub_category> Sub_categories{get;set;} = new List<Sub_category>();
    }
}