using System.ComponentModel.DataAnnotations;

namespace Student_MVC.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public Gender Gender { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
    public enum Gender
    {
        Male, Female
    }
}
