using System.Collections.Generic;
namespace ForumApi.Domain.Models
{
    public class Status
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public IList<Message> Messages{get;set;} = new List<Message>();
    }
}