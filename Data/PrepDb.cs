using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using Microsoft.EntityFrameworkCore;

namespace  PlatformService.Data
{
 
 public static class PrepDb
 {

   public static void  PrepPopulation(IApplicationBuilder app,bool isProduction)
   {
       using(var ServiceScope = app.ApplicationServices.CreateScope())
       {
          SeedData(ServiceScope.ServiceProvider.GetService<AppDbContext>(),isProduction);
       }
   }

   private static void SeedData(AppDbContext context, bool isProduction)
   {

     if(isProduction)
     {
       try
       {
          context.Database.Migrate();
          Console.WriteLine("--> Applying migration successfully");
       }
       catch(Exception ex)
       {
         Console.WriteLine($"--> Applying migration failed {ex.Message}");
       }

        
     }

      if(!context.Platforms.Any())
      {

          Console.WriteLine("-- Seeding Data");

           context.Platforms.AddRange(new Platform()
            {Name ="DotNet", Publisher ="Microsoft",Cost ="Free"},new Platform()
            {Name ="Sql Server Express", Publisher ="Microsoft",Cost ="Free"},new Platform()
            {Name ="Kubernetees", Publisher ="Cloud",Cost ="Free"});

           context.SaveChanges(); 
      }
      else
      {
          Console.WriteLine("-- We have already Data");

      }
   }

 }
  
}
