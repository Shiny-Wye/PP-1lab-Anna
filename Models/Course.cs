using System.Text.Json.Serialization;

namespace PP_1lab_Anna.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int? GroupId { get; set; }
        [JsonIgnore]
        public Group? Group { get; set; }
        //public Group? Group { get; set; }
    }
}
