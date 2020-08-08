using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class Category_Response : Base_Response
    {
        public Category_Response(bool success, string message,Category Category) : base(success, message)
        {
            this.Category = Category;
        }
        public Category Category{get;private set;}
        public Category_Response(Category Category):this(true,string.Empty,Category){}
        public Category_Response(string mes):this(false,mes,null){}
    }
}