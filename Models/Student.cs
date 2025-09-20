namespace StageConnect.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}

