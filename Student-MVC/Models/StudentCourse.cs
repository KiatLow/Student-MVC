using System.ComponentModel.DataAnnotations;

namespace Student_MVC.Models
{
    public class StudentCourse
    {
        [Key]
        public int StudentCourseId { get; set; }
        public double Score { get; set; }
        public string Grade
        {
            get
            {
                if (Score >= 80 && Score <= 100)
                {
                    return "A";
                }
                else if (Score >= 70 && Score < 80)
                {
                    return "B";
                }
                else if (Score >= 60 && Score < 70)
                {
                    return "C";
                }
                else if (Score >= 50 && Score < 60)
                {
                    return "D";
                }
                else if (Score >= 40 && Score < 50)
                {
                    return "E";
                }
                else if (Score >= 0 && Score < 40)
                {
                    return "F";
                }
                else
                {
                    return "";
                }
            }
        }
        public string Status
        {
            get
            {
                if (Score >= 40)
                {
                    return "Pass";
                }
                else
                {
                    return "Fail";
                }
            }
        }
        public Student Student { get; set; }
        public Trainer Trainer { get; set; }
        public Course Course { get; set; }
    }
}
