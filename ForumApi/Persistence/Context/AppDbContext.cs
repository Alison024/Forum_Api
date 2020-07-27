using System;
using Microsoft.EntityFrameworkCore;
using ForumApi.Domain.Models;
namespace ForumApi.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Avatar_image> Avatar_Images{get;set;}
        public DbSet<Category> Categories{get;set;}
        public DbSet<Image> Images{get;set;}
        public DbSet<Message> Messages{get;set;}
        public DbSet<Post> Posts{get;set;}
        public DbSet<Post_image> Post_Images{get;set;}
        public DbSet<Post_sub_category> Post_Sub_Categories{get;set;}
        public DbSet<Post_type> Post_Types{get;set;}
        public DbSet<Role> Roles{get;set;}
        public DbSet<Status> Statuses{get;set;}
        public DbSet<Sub_category> Sub_Categories{get;set;}
        public DbSet<User> Users{get;set;}
        public DbSet<User_info> User_Info{get;set;}
        public DbSet<User_role> User_Roles{get;set;}
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<Avatar_image>().ToTable("Avatar_images");
            builder.Entity<Avatar_image>().HasKey(x=>x.Id);
            builder.Entity<Avatar_image>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Avatar_image>().Property(x=>x.File_name).IsRequired();
            builder.Entity<Avatar_image>().HasMany(x=>x.Users).WithOne(x=>x.Avatar_Image);
            
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(x=>x.Id);
            //builder.Entity<Category>().Property(x=>x.Title).IsRequired();
            builder.Entity<Category>().HasOne(x=>x.Sub_category).WithMany(x=>x.Categories);

            builder.Entity<Image>().ToTable("Images");
            builder.Entity<Image>().HasKey(x=>x.Id);
            //builder.Entity<Image>().Property(x=>x.File_Name).IsRequired();
            builder.Entity<Image>().HasOne(x=>x.Post_Image).WithMany(x=>x.Images);
            
            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().HasKey(x=>x.Id);
            builder.Entity<Message>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Message>().Property(x=>x.Sender_Id).IsRequired();
            builder.Entity<Message>().Property(x=>x.Send_Time).IsRequired();
            builder.Entity<Message>().Property(x=>x.Content).IsRequired();
            builder.Entity<Message>().Property(x=>x.Status_Id).IsRequired();
            builder.Entity<Message>().HasMany(x=>x.Statuses).WithOne(x=>x.Message);
            builder.Entity<Message>().HasMany(x=>x.Senders).WithOne(z=>z.Sended_Message);
            builder.Entity<Message>().HasMany(x=>x.Receivers).WithOne(z=>z.Received_Message);

            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Post>().HasKey(x=>x.Id);
            builder.Entity<Post>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Post>().Property(x=>x.Author_Id).IsRequired();
            builder.Entity<Post>().Property(x=>x.Paren_Post_Id).IsRequired();
            builder.Entity<Post>().Property(x=>x.Post_Type_Id).IsRequired();
            builder.Entity<Post>().Property(x=>x.Title).IsRequired();
            builder.Entity<Post>().Property(x=>x.Content).IsRequired();
            builder.Entity<Post>().Property(x=>x.Date).IsRequired();
            builder.Entity<Post>().Property(x=>x.Post_Rate).IsRequired();
            builder.Entity<Post>().HasMany(x=>x.Authors).WithOne(x=>x.Post);
            builder.Entity<Post>().HasOne(x=>x.Parent_Post).WithMany(x=>x.Posts);
            builder.Entity<Post>().HasMany(x=>x.Post_Types).WithOne(x=>x.Post);
            builder.Entity<Post>().HasOne(x=>x.Post_Image).WithMany(x=>x.Posts);
            builder.Entity<Post>().HasOne(x=>x.Post_Sub_Category).WithMany(x=>x.Posts);

            builder.Entity<Post_image>().ToTable("Post_image");
            builder.Entity<Post_image>().HasKey(x=>new{x.Image_Id,x.Post_Id});
            builder.Entity<Post_image>().Property(x=>x.Image_Id).IsRequired();
            builder.Entity<Post_image>().Property(x=>x.Post_Id).IsRequired();
            builder.Entity<Post_image>().HasMany(x=>x.Images).WithOne(x=>x.Post_Image);
            builder.Entity<Post_image>().HasMany(x=>x.Posts).WithOne(x=>x.Post_Image);
            
            builder.Entity<Post_sub_category>().ToTable("Post_sub_category");
            builder.Entity<Post_sub_category>().HasKey(x=>new{x.Sub_Category_Id, x.Post_Id});
            builder.Entity<Post_sub_category>().Property(x=>x.Post_Id).IsRequired();
            builder.Entity<Post_sub_category>().Property(x=>x.Sub_Category_Id).IsRequired();
            builder.Entity<Post_sub_category>().HasMany(x=>x.Posts).WithOne(x=>x.Post_Sub_Category);
            builder.Entity<Post_sub_category>().HasMany(x=>x.Sub_Categories).WithOne(x=>x.Post_Sub_Category);
            
            builder.Entity<Post_type>().ToTable("Post_types");
            builder.Entity<Post_type>().HasKey(x=>x.Id);
            builder.Entity<Post_type>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Post_type>().Property(x=>x.Name).IsRequired();
            builder.Entity<Post_type>().HasOne(x=>x.Post).WithMany(x=>x.Post_Types);

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(x=>x.Id);
            builder.Entity<Role>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(x=>x.Name).IsRequired();
            builder.Entity<Role>().HasOne(x=>x.User_Role).WithMany(x=>x.Roles);

            builder.Entity<Status>().ToTable("Statuses");
            builder.Entity<Status>().HasKey(x=>x.Id);
            builder.Entity<Status>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Status>().Property(x=>x.Name).IsRequired();
            builder.Entity<Status>().HasOne(x=>x.Message).WithMany(x=>x.Statuses);
            
            builder.Entity<Sub_category>().ToTable("Sub_categories");
            builder.Entity<Sub_category>().HasKey(x=>x.Id);
            builder.Entity<Sub_category>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Sub_category>().Property(x=>x.Titile).IsRequired();
            builder.Entity<Sub_category>().HasMany(x=>x.Categories).WithOne(x=>x.Sub_category);
            builder.Entity<Sub_category>().HasOne(x=>x.Post_Sub_Category).WithMany(x=>x.Sub_Categories);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(x=>x.Id);
            builder.Entity<User>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(x=>x.Name).IsRequired();
            builder.Entity<User>().Property(x=>x.Surname).IsRequired();
            builder.Entity<User>().Property(x=>x.User_Name).IsRequired();
            builder.Entity<User>().Property(x=>x.Email).IsRequired();
            builder.Entity<User>().Property(x=>x.Phone_Number).IsRequired();
            builder.Entity<User>().Property(x=>x.Birthday).IsRequired();
            builder.Entity<User>().Property(x=>x.Avatar_id).IsRequired();
            builder.Entity<User>().HasMany(x=>x.Avatar_Images).WithOne(x=>x.User);
            builder.Entity<User>().HasOne(x=>x.User_Info).WithMany(x=>x.Users);
            builder.Entity<User>().HasOne(x=>x.Sended_Message).WithMany(x=>x.Senders);
            builder.Entity<User>().HasOne(x=>x.Received_Message).WithMany(x=>x.Receivers);
            builder.Entity<User>().HasOne(x=>x.User_Role).WithMany(x=>x.Users);
            builder.Entity<User>().HasOne(x=>x.Post).WithMany(x=>x.Authors);

            builder.Entity<User_info>().ToTable("User_info");
            builder.Entity<User_info>().HasKey(x=>x.Id);
            builder.Entity<User_info>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User_info>().Property(x=>x.User_Id);
            builder.Entity<User_info>().Property(x=>x.User_Rate);
            builder.Entity<User_info>().Property(x=>x.Comments);
            builder.Entity<User_info>().Property(x=>x.Answers);
            builder.Entity<User_info>().Property(x=>x.Questions);
            builder.Entity<User_info>().HasMany(x=>x.Users).WithOne(x=>x.User_Info);

            builder.Entity<User_role>().ToTable("User_roles");
            builder.Entity<User_role>().HasKey(x=> new {x.User_id,x.Role_id});
            builder.Entity<User_role>().Property(x=>x.User_id).IsRequired();
            builder.Entity<User_role>().Property(x=>x.Role_id).IsRequired();
            builder.Entity<User_role>().Property(x=>x.User_id).IsRequired();
            builder.Entity<User_role>().HasMany(x=>x.Users).WithOne(x=>x.User_Role);
            builder.Entity<User_role>().HasMany(x=>x.Roles).WithOne(x=>x.User_Role);
        }
    }
}