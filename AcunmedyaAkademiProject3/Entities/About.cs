namespace AcunmedyaAkademiProject3.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }

        public About()
        {
            Title = string.Empty;
            ImageUrl = string.Empty;
            VideoUrl = string.Empty;
            Description1 = string.Empty;
            Description2 = string.Empty;
        }
    }
}