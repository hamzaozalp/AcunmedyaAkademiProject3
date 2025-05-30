namespace AcunmedyaAkademiProject3.Entities
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }

        public Experience()
        {
            Title = string.Empty;
            CompanyName = string.Empty;
            StartDate = string.Empty;
            EndDate = string.Empty;
            Description = string.Empty;
        }
    }
} 