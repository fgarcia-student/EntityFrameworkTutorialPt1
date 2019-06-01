using System.Collections.Generic;

namespace EntityFrameworkExample.Models
{
  public class ClassRoom
  {
    public int Id { get; set; }

    public string RoomName { get; set; }

    public ICollection<Teacher> Teachers { get; set; }

    public ICollection<Student> Students { get; set; }
  }
}