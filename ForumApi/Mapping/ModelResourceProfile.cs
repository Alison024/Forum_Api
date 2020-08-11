using System;
using System.Linq;
using AutoMapper;
using ForumApi.Resources;
using ForumApi.Domain.Models;
namespace ForumApi.Mapping
{
    public class ModelResourceProfile:Profile
    {
        public ModelResourceProfile()
        {
            CreateMap<Avatar_image,Avatar_Image_Resource>();
            CreateMap<Avatar_Image_Resource,Avatar_image>();

            CreateMap<Category,Category_Resource>();
            CreateMap<Category_Resource,Category>();

            CreateMap<Image,Image_Resource>();
            CreateMap<Image_Resource,Image>();

            CreateMap<Message,Message_Resource>();
            CreateMap<Message_Resource,Message>();

            CreateMap<Post,Post_Resource>();
            CreateMap<Post_Resource,Post>();

            CreateMap<Post_image,Post_Image_Resource>();
            CreateMap<Post_Image_Resource,Post_image>();

            CreateMap<Post_sub_category,Post_Sub_Category_Resource>();
            CreateMap<Post_Sub_Category_Resource,Post_sub_category>();

            CreateMap<Post_type,Post_Type_Resource>();
            CreateMap<Post_Type_Resource,Post_type>();

            CreateMap<Role,Role_Resource>();
            CreateMap<Role_Resource,Role>();

            CreateMap<Status,Status_Resource>();
            CreateMap<Status_Resource,Status>();

            CreateMap<Sub_category,Sub_Category_Resource>();
            CreateMap<Sub_Category_Resource,Sub_category>();

            CreateMap<User,User_Resource>();
            CreateMap<User_Resource,User>();

            CreateMap<User_info,User_Info_Resource>();
            CreateMap<User_Info_Resource,User_info>();

            CreateMap<User_role,User_Role_Resource>();
            CreateMap<User_Role_Resource,User_role>();

            CreateMap<Register_User_Resource,User>().ForMember(x=>x.Birthday,o=>o.MapFrom(x=>Convert.ToDateTime(x.Birthday)));
        }
    }
}