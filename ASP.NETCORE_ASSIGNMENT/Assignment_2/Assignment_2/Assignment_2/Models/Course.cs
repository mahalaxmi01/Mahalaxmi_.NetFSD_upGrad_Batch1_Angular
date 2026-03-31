namespace Assignment_2.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        // Foreign Key
        public int StudentId { get; set; }

        // Navigation Property
        public Student? Student { get; set; }
    }
}
