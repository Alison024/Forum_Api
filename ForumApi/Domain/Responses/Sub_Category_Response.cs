using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class Sub_Category_Response : Base_Response
    {
        public Sub_Category_Response(bool success, string message,Sub_category sub_Category) : base(success, message)
        {
            this.sub_Category = sub_Category;
        }
        public Sub_category sub_Category{get;private set;}
        public Sub_Category_Response(Sub_category sub_Category):this(true,string.Empty,sub_Category){}
        public Sub_Category_Response(string mes):this(false,mes,null){}
    }
}