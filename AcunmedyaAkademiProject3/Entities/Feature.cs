namespace AcunmedyaAkademiProject3.Entities
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public string ImageUrl { get; set; }

        public Feature()
        {
            Title = string.Empty;
            Description = string.Empty;
            IconUrl = string.Empty;
            ImageUrl = string.Empty;
        }
    }
}