using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ForumApi.Persistence.Context;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Repositories;
using ForumApi.Domain.IServices;
using ForumApi.Services;
using AutoMapper;
namespace ForumApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<AppDbContext>(options=>options.UseSqlServer("Data Source=DESKTOP-VAOFU4A;Initial Catalog=ForumApi;Integrated Security=True").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddAutoMapper(typeof(Startup));
            
            //services.AddTransient<DbContext,AppDbContext>();
            services.AddScoped<IUnit_Of_Work,UnitOfWork>();
            services.AddScoped<IAvatar_Images_Repository,AvatarImageRepository>();
            services.AddScoped<ICategory_Repository,CategoryRepository>();
            services.AddScoped<IImage_Repository,ImageRepository>();
            services.AddScoped<IMessage_Reposirtory,MessageRepository>();
            services.AddScoped<IPost_Image_Repository,PostImageRepository>();
            services.AddScoped<IPost_Repository,PostRepository>();
            services.AddScoped<IPost_Sub_Category_Repository,PostSubCategoryRepository>();
            services.AddScoped<IPost_Type_Repository,PostTypeRepository>();
            services.AddScoped<IRole_Repository,RoleRepository>();
            services.AddScoped<IStatus_Repository,StatusRepository>();
            services.AddScoped<ISub_Category_Repository,SubCategoryRepository>();
            services.AddScoped<IUser_Info_Repository,UserInfoRepository>();
            services.AddScoped<IUser_Repository,UserRepository>();
            services.AddScoped<IUser_Role_Repository,UserRoleRepository>();

            services.AddScoped<IAvatar_Image_Service,Avatar_Image_Service>();
            services.AddScoped<ICategory_Service,Category_Service>();
            services.AddScoped<IImage_Service,Image_Service>();
            services.AddScoped<IMessage_Service,Message_Service>();
            services.AddScoped<IPost_Image_Service,Post_Image_Service>();
            services.AddScoped<IPost_Service,Post_Service>();
            services.AddScoped<IPost_Sub_Category_Service,Post_Sub_Category_Service>();
            services.AddScoped<IPost_Type_Service,Post_Type_Service>();
            services.AddScoped<IRole_Service,Role_Service>();
            services.AddScoped<IStatus_Service,Status_Service>();
            services.AddScoped<ISub_Category_Service,Sub_Category_Service>();
            services.AddScoped<IUser_Info_Service,User_Info_Service>();
            services.AddScoped<IUser_Role_Service,User_Role_Service>();
            services.AddScoped<IUser_Service,User_Service>();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
