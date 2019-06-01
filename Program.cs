using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExample.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkExample
{
  public class Program
  {
    public static void Main(string[] args)
    {
      SeedDatabase();
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    public static void SeedDatabase()
    {
      using (var dbContext = new ApplicationContext())
      {
        if (dbContext.ClassRoom.Count(x => x.RoomName == "Sunshine Room") == 1)
        {
          return;
        }
        dbContext.ClassRoom.Add(new ClassRoom()
        {
          RoomName = "Sunshine Room"
        });
        dbContext.ClassRoom.Add(new ClassRoom()
        {
          RoomName = "Moonlight Room"
        });
        dbContext.SaveChanges();
        var classRoom = dbContext.ClassRoom.Where(x => x.RoomName == "Sunshine Room").FirstOrDefault();
        dbContext.Teacher.Add(new Teacher()
        {
          Name = "Mrs. Tonkin",
          ClassRoomId = classRoom.Id,
          ClassRoom = classRoom
        });
        dbContext.Student.Add(new Student()
        {
          Name = "Tom",
          Grade = 'A',
          ClassRoomId = classRoom.Id,
          ClassRoom = classRoom
        });
        dbContext.Student.Add(new Student()
        {
          Name = "Mary",
          Grade = 'A',
          ClassRoomId = classRoom.Id,
          ClassRoom = classRoom
        });
        dbContext.Student.Add(new Student()
        {
          Name = "Richard",
          Grade = 'D',
          ClassRoomId = classRoom.Id,
          ClassRoom = classRoom
        });
        dbContext.SaveChanges();
      }
    }
  }
}
