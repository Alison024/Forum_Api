
namespace ForumApi.Resources
{
    public class User_Resource
    {
        public int Id{get;set;}
        public int Avatar_Id{get;set;}
        public int User_Info_Id{get;set;}
        public string Name{get;set;}
        public string Surname{get;set;}
        public string User_Name{get;set;}
        public string Email{get;set;}
        public string Phone_Number{get;set;}
        public User_Info_Resource User_Info{get;set;}
    }
}