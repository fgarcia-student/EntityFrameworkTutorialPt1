using Newtonsoft.Json;

namespace EntityFrameworkExample.Models
{
  public class Student
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public char Grade { get; set; }

    public int ClassRoomId { get; set; }

    [JsonIgnore]
    public ClassRoom ClassRoom { get; set; }
  }
}