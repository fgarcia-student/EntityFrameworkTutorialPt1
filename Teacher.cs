using Newtonsoft.Json;

namespace EntityFrameworkExample.Models
{
  public class Teacher
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public int ClassRoomId { get; set; }

    [JsonIgnore]
    public ClassRoom ClassRoom { get; set; }
  }
}