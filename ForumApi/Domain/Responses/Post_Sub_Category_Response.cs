using ForumApi.Domain.Models;
namespace ForumApi.Domain.Responses
{
    public class Post_Sub_Category_Response : Base_Response
    {
        public Post_Sub_Category_Response(bool success, string message,Post_sub_category post_Sub_Category) : base(success, message)
        {
            this.post_Sub_Category = post_Sub_Category;
        }
        public Post_sub_category post_Sub_Category{get;private set;}
        public Post_Sub_Category_Response(Post_sub_category post_Sub_Category):this(true,string.Empty,post_Sub_Category){}
        public Post_Sub_Category_Response(string mes):this(false,mes,null){}
    }
}