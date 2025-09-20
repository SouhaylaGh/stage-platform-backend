namespace StageConnect.DTOs
{
    public class InternshipOfferDto
    {
        public string Title { get; set; }
        public string Domain { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Mode { get; set; }
        public string Address { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public string Profile { get; set; }
        public string Competences { get; set; }
        public string Languages { get; set; }
        public string Salary { get; set; }
        public int Positions { get; set; }
        public string Benefits { get; set; }
        public bool Urgent { get; set; }
        public bool Remote { get; set; }
        public bool Housing { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string Instructions { get; set; }
        public List<string> Skills { get; set; }
    }
}
