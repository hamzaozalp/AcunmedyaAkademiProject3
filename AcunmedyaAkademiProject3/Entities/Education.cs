namespace AcunmedyaAkademiProject3.Entities
{
    public class Education
    {
        public int EducationId { get; set; }
        public string SchoolName { get; set; }
        public string Department { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public Education()
        {
            SchoolName = string.Empty;
            Department = string.Empty;
            StartDate = string.Empty;
            EndDate = string.Empty;
        }
    }
} 