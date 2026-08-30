namespace StudentManagementApp.Models
{
    public class Grade
    {
        public int GradeId { get; set; }

        public string GradeName { get; set; } = string.Empty;

        public string Section { get; set; } = string.Empty;

        public int StudentId { get; set; }

        public Student Student { get; set; } = null!;
    }
}