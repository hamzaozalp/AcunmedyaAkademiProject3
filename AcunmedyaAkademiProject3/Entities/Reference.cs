namespace AcunmedyaAkademiProject3.Entities
{
    public class Reference
    {
        public int ReferenceId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }

        public Reference()
        {
            FullName = string.Empty;
            Title = string.Empty;
            Message = string.Empty;
            ImageUrl = string.Empty;
        }
    }
} 