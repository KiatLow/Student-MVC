using System.ComponentModel.DataAnnotations;

namespace Student_MVC.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
