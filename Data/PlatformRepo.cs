namespace PlatformService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlatformService.Models;
  public class PlatformRepo : IPlatformRepo
  {

  private readonly  AppDbContext _context;  

   public PlatformRepo(AppDbContext context)
   {
       _context = context;
   }


   public IEnumerable<Platform> GetAllPlatforms()
   {
     return _context.Platforms.ToList();
   }

   public Platform GetPlatformById(int Id)
   {
      return _context.Platforms.FirstOrDefault(p =>p.Id == Id);
   }

   public void CreatePlatform(Platform platform)
   {
       if(platform ==  null)
       {
         throw new  ArgumentNullException(nameof(platform));
       }

       _context.Platforms.Add(platform);
   }

   public bool SaveChanges()
   {
      return (_context.SaveChanges()>0);
   }  

  
  }

}