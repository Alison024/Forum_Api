using System;
using Microsoft.EntityFrameworkCore;
using ForumApi.Domain.Models;
using ForumApi.Helpers;
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
            builder.Entity<Avatar_image>().Property(x=>x.File_Name).IsRequired();
            builder.Entity<Avatar_image>().HasMany(x=>x.Users).WithOne(x=>x.Avatar_Image);
            builder.Entity<Avatar_image>().HasData(
                new Avatar_image{Id = 1, File_Name="unknown-512.pn", 
                Image_Url="https://cdn1.iconfinder.com/data/icons/user-pictures/100/unknown-512.png"}
            );
            
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(x=>x.Id);
            builder.Entity<Category>().Property(x=>x.Title).IsRequired();
            builder.Entity<Category>().HasMany(x=>x.Sub_categories).WithOne(x=>x.Category);
            builder.Entity<Category>().HasData(
                new Category{Id = 1, Title = "Rudiments of music"},
                new Category{Id = 2, Title = "Musical exercises"},
                new Category{Id = 3, Title = "Looking for Group"},
                new Category{Id = 4, Title = "Life"}
            );
            builder.Entity<Image>().ToTable("Images");
            builder.Entity<Image>().HasKey(x=>x.Id);
            builder.Entity<Image>().HasMany(x=>x.Post_Images).WithOne(x=>x.Image);
            builder.Entity<Image>().HasData(
                new Image{Id = 1,File_Name = "8a5ad1a7ee81e7acabe80682b312d2d8.jpg",Image_Data= null,
                Image_Url = "https://i.pinimg.com/originals/8a/5a/d1/8a5ad1a7ee81e7acabe80682b312d2d8.jpg"},
                new Image{Id = 2,File_Name = "5e04c21a52a39.jpg",Image_Data= null,
                Image_Url = "https://millionstatusov.ru/pic/statpic/all8/5e04c21a52a39.jpg"},
                new Image{Id = 3,File_Name = "c0b77faeb2cb3e67fd1b423c4535f6c3.jpg",Image_Data= null,
                Image_Url = "https://i.pinimg.com/originals/c0/b7/7f/c0b77faeb2cb3e67fd1b423c4535f6c3.jpg"}
            );
            
            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().HasKey(x=>x.Id);
            builder.Entity<Message>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Message>().Property(x=>x.Sender_Id).IsRequired();
            //builder.Entity<Message>().Property(x=>x.Receiver_Id);
            builder.Entity<Message>().Property(x=>x.Send_Time).IsRequired();
            builder.Entity<Message>().Property(x=>x.Message_Content).IsRequired();
            builder.Entity<Message>().Property(x=>x.Status_Id).IsRequired();
            builder.Entity<Message>().HasOne(x=>x.Status).WithMany(x=>x.Messages).HasForeignKey(x=>x.Status_Id);
            builder.Entity<Message>().HasOne(x=>x.Sender).WithMany(z=>z.Sended_Messages).HasForeignKey(x=>x.Sender_Id).OnDelete(DeleteBehavior.ClientSetNull);//нужно разобратся с удалением
            builder.Entity<Message>().HasOne(x=>x.Receiver).WithMany(z=>z.Received_Messages).HasForeignKey(x=>x.Receiver_Id).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Message>().HasData(
                new Message{Id = 1,Sender_Id = 1, Receiver_Id = 2, Send_Time = new DateTime(2020,08,15,13,40,15),
                Message_Content = "Are you finish your project ?", Status_Id = 1},
                new Message{Id = 2,Sender_Id = 2, Receiver_Id = 1, Send_Time = new DateTime(2020,08,15,13,45,00),
                Message_Content = "Sorry, i can't do it in time (", Status_Id = 1},
                new Message{Id = 3,Sender_Id = 2, Receiver_Id = 1, Send_Time = new DateTime(2020,08,15,13,45,20),
                Message_Content = "Can I send it later ?", Status_Id = 1},
                new Message{Id = 4,Sender_Id = 1, Receiver_Id = 2, Send_Time = new DateTime(2020,08,15,13,50,15),
                Message_Content = "Okey, but only once!", Status_Id = 1},
                new Message{Id = 5,Sender_Id = 2, Receiver_Id = 1, Send_Time = new DateTime(2020,08,15,13,59,31),
                Message_Content = "Thank you!!!!", Status_Id = 1},
                new Message{Id = 6,Sender_Id = 3, Receiver_Id = 4, Send_Time = new DateTime(2020,08,18,12,40,20),
                Message_Content = "Are you fine ?", Status_Id = 1},
                new Message{Id = 7,Sender_Id = 4, Receiver_Id = 3, Send_Time = new DateTime(2020,08,15,13,40,15),
                Message_Content = "Yes, thanks", Status_Id = 1},
                new Message{Id = 8,Sender_Id = 1, Receiver_Id = 1, Send_Time = new DateTime(2020,08,13,08,00,00),
                Message_Content = "I need to buy eggs today!", Status_Id = 1}
            );

            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Post>().HasKey(x=>x.Id);
            builder.Entity<Post>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Post>().Property(x=>x.Author_Id).IsRequired();
            builder.Entity<Post>().Property(x=>x.Paren_Post_Id).HasDefaultValue(null);
            builder.Entity<Post>().Property(x=>x.Post_Type_Id).IsRequired();
            builder.Entity<Post>().Property(x=>x.Title).IsRequired();
            builder.Entity<Post>().Property(x=>x.Post_Content).IsRequired();
            builder.Entity<Post>().Property(x=>x.Date).IsRequired();
            builder.Entity<Post>().Property(x=>x.Post_Rate).IsRequired();
            builder.Entity<Post>().HasOne(x=>x.Author).WithMany(x=>x.Posts).HasForeignKey(x=>x.Author_Id);
            builder.Entity<Post>().HasOne(x=>x.Parent_Post).WithMany(x=>x.Children_Posts).OnDelete(DeleteBehavior.ClientSetNull);/*Не удалось создать внешний ключ "FK_Posts_Posts_Paren_Post_Id" со ссылочным действием SET NULL, поскольку один или несколько ссылающихся столбцов не допускают значения NULL.*/ //.HasForeignKey(x=>x.Paren_Post_Id) wtf ?
            builder.Entity<Post>().HasOne(x=>x.Post_Type).WithMany(x=>x.Posts).HasForeignKey(x=>x.Post_Type_Id);
            builder.Entity<Post>().HasMany(x=>x.Post_Images).WithOne(x=>x.Post);
            builder.Entity<Post>().HasMany(x=>x.Post_Sub_Categories).WithOne(x=>x.Post);
            builder.Entity<Post>().HasData(
                new Post{
                    Id = 1,
                    Author_Id = 1,
                    Post_Type_Id = 1,
                    Title = "First info post",
                    Post_Content = "Rules of musical forum: \n... bla... bla... bla... bla", 
                    Post_Rate = 100000,
                    Date = new DateTime(2020,08,01,12,00,00) 
                },
                new Post{
                    Id = 2,
                    Author_Id = 2,
                    Post_Type_Id = 3,
                    Title = "Which company is better to buy a guitar ???",
                    Post_Content = "Hello, I want to buy a guitar for my first time but I don’t know anything about them, so please, help me to choose.",
                    Post_Rate = 1,
                    Date = new DateTime(2020,08,01,13,00,00) 
                },
                new Post{
                    Id = 3,
                    Author_Id = 3,
                    Post_Type_Id = 4,
                    Title = "Searching tutor for my son to play on violin! ",
                    Post_Content = "If you interesting plese write to me private message.", 
                    Post_Rate = 1,
                    Date = new DateTime(2020,08,01,14,00,00) 
                },
                new Post{
                    Id = 4,
                    Author_Id = 5,
                    Post_Type_Id = 5,
                    Title = "When you perform in front of a big audience",
                    Post_Content = "", 
                    Post_Rate = 1,
                    Date = new DateTime(2020,08,01,15,00,00) 
                }
            );
            builder.Entity<Post_image>().ToTable("Post_image");
            builder.Entity<Post_image>().HasKey(x=>new{x.Image_Id,x.Post_Id});
            builder.Entity<Post_image>().Property(x=>x.Image_Id).IsRequired();
            builder.Entity<Post_image>().Property(x=>x.Post_Id).IsRequired();
            builder.Entity<Post_image>().HasOne(x=>x.Image).WithMany(x=>x.Post_Images).HasForeignKey(x=>x.Image_Id);
            builder.Entity<Post_image>().HasOne(x=>x.Post).WithMany(x=>x.Post_Images).HasForeignKey(x=>x.Post_Id);
            builder.Entity<Post_image>().HasData(
                new Post_image{Post_Id = 2, Image_Id = 1},
                new Post_image{Post_Id = 2, Image_Id = 2},
                new Post_image{Post_Id = 4, Image_Id = 3}
            );
            
            builder.Entity<Post_sub_category>().ToTable("Post_sub_category");
            builder.Entity<Post_sub_category>().HasKey(x=>new{x.Sub_Category_Id, x.Post_Id});
            builder.Entity<Post_sub_category>().Property(x=>x.Post_Id).IsRequired();
            builder.Entity<Post_sub_category>().Property(x=>x.Sub_Category_Id).IsRequired();
            builder.Entity<Post_sub_category>().HasOne(x=>x.Post).WithMany(x=>x.Post_Sub_Categories).HasForeignKey(x=>x.Post_Id);
            builder.Entity<Post_sub_category>().HasOne(x=>x.Sub_Categories).WithMany(x=>x.Post_Sub_Categories).HasForeignKey(x=>x.Sub_Category_Id);
            builder.Entity<Post_sub_category>().HasData(
                new Post_sub_category{Post_Id = 2, Sub_Category_Id = 5},
                new Post_sub_category{Post_Id = 3, Sub_Category_Id = 4},
                new Post_sub_category{Post_Id = 3, Sub_Category_Id = 13},
                new Post_sub_category{Post_Id = 4, Sub_Category_Id = 11}
            );
            builder.Entity<Post_type>().ToTable("Post_types");
            builder.Entity<Post_type>().HasKey(x=>x.Id);
            builder.Entity<Post_type>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Post_type>().Property(x=>x.Name).IsRequired();
            builder.Entity<Post_type>().HasMany(x=>x.Posts).WithOne(x=>x.Post_Type);
            builder.Entity<Post_type>().HasData(
                new Post_type{Id = 1, Name = "News"},
                new Post_type{Id = 2, Name = "Event"},
                new Post_type{Id = 3, Name = "Question"},
                new Post_type{Id = 4, Name = "Vacancy"},
                new Post_type{Id = 5, Name = "Joke"}
            );

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(x=>x.Id);
            builder.Entity<Role>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(x=>x.Name).IsRequired();
            builder.Entity<Role>().HasMany(x=>x.User_Roles).WithOne(x=>x.Role);
            builder.Entity<Role>().HasData(
                new Role{Id = 1, Name = "Admin"},
                new Role{Id = 2, Name = "Moderator"},
                new Role{Id = 3, Name = "User"}
            );
            builder.Entity<Status>().ToTable("Statuses");
            builder.Entity<Status>().HasKey(x=>x.Id);
            builder.Entity<Status>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Status>().Property(x=>x.Name).IsRequired();
            builder.Entity<Status>().HasMany(x=>x.Messages).WithOne(x=>x.Status);
            builder.Entity<Status>().HasData(
                new Status{Id = 1, Name = "Sent"},
                new Status{Id = 2, Name = "Read"},
                new Status{Id = 3, Name = "Failure"}
            );
            
            builder.Entity<Sub_category>().ToTable("Sub_categories");
            builder.Entity<Sub_category>().HasKey(x=>x.Id);
            builder.Entity<Sub_category>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Sub_category>().Property(x=>x.Titile).IsRequired();
            builder.Entity<Sub_category>().HasOne(x=>x.Category).WithMany(x=>x.Sub_categories).HasForeignKey(x=>x.Category_Id);
            builder.Entity<Sub_category>().HasMany(x=>x.Post_Sub_Categories).WithOne(x=>x.Sub_Categories);
            builder.Entity<Sub_category>().HasData(
                new Sub_category{Id = 1, Titile = "How to play jazz", Category_Id = 1},
                new Sub_category{Id = 2, Titile = "How to play metal", Category_Id = 1},
                new Sub_category{Id = 3, Titile = "How to play rock", Category_Id = 1},
                new Sub_category{Id = 4, Titile = "for the violin players", Category_Id = 2},
                new Sub_category{Id = 5, Titile = "for the guitar players", Category_Id = 2},
                new Sub_category{Id = 6, Titile = "for the piano players", Category_Id = 2},
                new Sub_category{Id = 7, Titile = "for drummers", Category_Id = 2},
                new Sub_category{Id = 8, Titile = "Jazz group", Category_Id = 3},
                new Sub_category{Id = 9, Titile = "Rock group", Category_Id = 3},
                new Sub_category{Id = 10, Titile = "Metal group", Category_Id = 3},
                new Sub_category{Id = 11, Titile = "Health", Category_Id = 4},
                new Sub_category{Id = 12, Titile = "Style", Category_Id = 4},
                new Sub_category{Id = 13, Titile = "Education", Category_Id = 4}
            );

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(x=>x.Id);
            builder.Entity<User>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            /*builder.Entity<User>().Property(x=>x.Name).IsRequired();
            builder.Entity<User>().Property(x=>x.Surname).IsRequired();*/
            builder.Entity<User>().Property(x=>x.User_Name).IsRequired();
            builder.Entity<User>().Property(x=>x.Email).IsRequired();
            builder.Entity<User>().Property(x=>x.Password).IsRequired();
            //builder.Entity<User>().Property(x=>x.Phone_Number).IsRequired();
            builder.Entity<User>().Property(x=>x.Birthday).IsRequired();
            builder.Entity<User>().Property(x=>x.Avatar_Id).HasDefaultValue(1);
            builder.Entity<User>().HasOne(x=>x.Avatar_Image).WithMany(x=>x.Users).HasForeignKey(x=>x.Avatar_Id);
            builder.Entity<User>().HasOne(x=>x.User_Info).WithOne(x=>x.User).HasForeignKey<User>(x=>x.User_Info_Id);
            builder.Entity<User>().HasMany(x=>x.Sended_Messages).WithOne(x=>x.Sender);
            builder.Entity<User>().HasMany(x=>x.Received_Messages).WithOne(x=>x.Receiver);
            builder.Entity<User>().HasMany(x=>x.User_Roles).WithOne(x=>x.User);
            builder.Entity<User>().HasMany(x=>x.Posts).WithOne(x=>x.Author);
            builder.Entity<User>().HasData(
                new User{Id = 1, 
                Avatar_Id = 1,
                User_Info_Id = 1,
                Name="Andrey",
                User_Name="Pikachu2000",
                Email="someE@gmail.com", 
                Password = Helper_MD5.GenerateMD5Hash("123123"), 
                Birthday = new DateTime(2000,7,20)},
                new User{Id = 2, 
                Avatar_Id = 1,
                User_Info_Id = 2,
                Name="Tolik",
                User_Name="super_man228",
                Email="someE2@gmail.com", 
                Password = Helper_MD5.GenerateMD5Hash("123456"), 
                Birthday = new DateTime(2002,10,31)},
                new User{Id = 3, 
                Avatar_Id = 1,User_Info_Id = 3,
                Name="Den",User_Name="NagibatorXXX",
                Email="someE3@gmail.com", 
                Password = Helper_MD5.GenerateMD5Hash("112233"), 
                Birthday = new DateTime(1995,2,2)},
                new User{Id = 4, 
                Avatar_Id = 1,
                User_Info_Id = 4,
                Name="Martin",
                User_Name="USA_Supper",
                Email="someE4@gmail.com", 
                Password = Helper_MD5.GenerateMD5Hash("654321"), 
                Birthday = new DateTime(2000,08,20)},
                new User{Id = 5, 
                Avatar_Id = 1,
                User_Info_Id = 5,
                Name="Jon",
                User_Name="Canada_Supper",
                Email="someE5@gmail.com", 
                Password = Helper_MD5.GenerateMD5Hash("445566"), 
                Birthday = new DateTime(1999,9,11)}
            );


            builder.Entity<User_info>().ToTable("User_info");
            builder.Entity<User_info>().HasKey(x=>x.Id);
            builder.Entity<User_info>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User_info>().Property(x=>x.User_Rate);
            builder.Entity<User_info>().Property(x=>x.Comments);
            builder.Entity<User_info>().Property(x=>x.Answers);
            builder.Entity<User_info>().Property(x=>x.Questions);
            builder.Entity<User_info>().HasOne(x=>x.User).WithOne(x=>x.User_Info);
            builder.Entity<User_info>().HasData(
                new User_info{Id=1,User_Rate=1,Comments=0,Answers=0,Questions=0},
                new User_info{Id=2,User_Rate=112,Comments=30,Answers=16,Questions=41},
                new User_info{Id=3,User_Rate=-30,Comments=10,Answers=5,Questions=5},
                new User_info{Id=4,User_Rate=1,Comments=0,Answers=0,Questions=1},
                new User_info{Id=5,User_Rate=1,Comments=0,Answers=0,Questions=0}
            );

            builder.Entity<User_role>().ToTable("User_roles");
            builder.Entity<User_role>().HasKey(x=> new {x.User_Id,x.Role_Id});
            builder.Entity<User_role>().Property(x=>x.User_Id).IsRequired();
            builder.Entity<User_role>().Property(x=>x.Role_Id).IsRequired();
            builder.Entity<User_role>().HasOne(x=>x.User).WithMany(x=>x.User_Roles).HasForeignKey(x=>x.User_Id);
            builder.Entity<User_role>().HasOne(x=>x.Role).WithMany(x=>x.User_Roles).HasForeignKey(x=>x.Role_Id);
            builder.Entity<User_role>().HasData(
                new User_role{User_Id = 1, Role_Id = 1},
                new User_role{User_Id = 1, Role_Id = 2},
                new User_role{User_Id = 1, Role_Id = 3},
                new User_role{User_Id = 2, Role_Id = 2},
                new User_role{User_Id = 2, Role_Id = 3},
                new User_role{User_Id = 3, Role_Id = 3}
            );
        }
    }
}