namespace StudentAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SchoolName { get; set; }
        public ExamResult? ExamResult { get; set; }
    }
}
