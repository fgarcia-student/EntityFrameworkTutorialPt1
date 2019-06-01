using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExample.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SchoolsController : ControllerBase
  {

    private readonly ApplicationContext _dbContext;

    public SchoolsController()
    {
      _dbContext = new ApplicationContext();
    }
    // GET api/values
    [HttpGet("classrooms")]
    public ActionResult<IList<ClassRoom>> GetAllClassRooms()
    {
      return _dbContext.ClassRoom.ToList();
    }

    [HttpGet("teachers")]
    public ActionResult<IList<Teacher>> GetTeachersInSpecificClassRoom(
      [FromQuery] string classRoomName
    )
    {
      var classRoom = _dbContext.ClassRoom
        .Where(x => x.RoomName == classRoomName)
        .Include(x => x.Teachers)
        .FirstOrDefault();

      if (classRoom == null)
      {
        return new List<Teacher>();
      }

      return classRoom.Teachers.ToList();

    }

    [HttpGet("students")]
    public ActionResult<IList<Student>> GetStudentsInSpecificClassRoom(
      [FromQuery] string classRoomName
    )
    {
      var classRoom = _dbContext.ClassRoom
        .Where(x => x.RoomName == classRoomName)
        .Include(x => x.Students)
        .FirstOrDefault();

      if (classRoom == null)
      {
        return new List<Student>();
      }

      return classRoom.Students.ToList();

    }
  }
}
