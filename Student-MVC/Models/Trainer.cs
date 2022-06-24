using System.ComponentModel.DataAnnotations;

namespace Student_MVC.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
