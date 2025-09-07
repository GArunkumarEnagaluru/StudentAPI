namespace StudentAPI.Models
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int English { get; set; }
        public int Telugu { get; set; }
        public int Hindi { get; set; }
        public int Mathematics { get; set; }
        public int Physics { get; set; }
        public int Social { get; set; }
    }
}
