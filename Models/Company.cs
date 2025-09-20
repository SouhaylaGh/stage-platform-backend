namespace StageConnect.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
