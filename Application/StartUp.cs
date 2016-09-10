
using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopLister.Model;

namespace ShopLister.App
{
    public class Startup { 
        
        private static readonly IAppConfig Config = new ShopListerConfig();

        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true);
                 builder.Build().Bind(Config);
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            //App config
            collection.AddSingleton<IAppConfig>(Config);
            
            //DB context
            collection.AddOperations<ShopListerOperations, ShopListerContext>();

            //AutoMapper
            ConfigAutoMapper();
            collection.AddSingleton(Mapper.Configuration);
            collection.AddScoped<IMapper>(sp => 
            new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            //MVC
            collection.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ShopListerContext dbContext) 
        { 
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler(new PathString("/error"));
            
            app.UseMvcWithDefaultRoute();

            // Database
            dbContext.Database.EnsureCreated();
        } 

        private void ConfigAutoMapper()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ListItem, ListItem>()
                .ForMember(member => member.Id, member => member.Ignore())
                .ForMember(member => member.Created, member => member.Ignore())
                .ForMember(member => member.Updated, member => member.Ignore());
            });
        }
    }
}