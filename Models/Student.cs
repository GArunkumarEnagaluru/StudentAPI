namespace StudentAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SchoolName { get; set; }
        public ExamResult? ExamResult { get; set; }
    }

    public class StudentPostModel
    {
        public string? Name { get; set; }
        public string? SchoolName { get; set; }
        public ExamResultPostModel? ExamResult { get; set; }
    }

    public class ExamResultPostModel
    {
        public int English { get; set; }
        public int Telugu { get; set; }
        public int Hindi { get; set; }
        public int Mathematics { get; set; }
        public int Physics { get; set; }
        public int Social { get; set; }
    }
}
