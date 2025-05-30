namespace AcunmedyaAkademiProject3.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }

        public SocialMedia()
        {
            Icon = string.Empty;
            Url = string.Empty;
            Username = string.Empty;
        }
    }
} 