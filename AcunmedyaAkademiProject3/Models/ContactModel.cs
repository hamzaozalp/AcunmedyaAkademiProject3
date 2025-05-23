namespace AcunmedyaAkademiProject3.Models
{
    public class ContactModel
    {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Subject { get; set; } // <-- Bu satır olmalı!
            public string Message { get; set; }
        

        public ContactModel()
        {
            Name = string.Empty;
            Email = string.Empty;
            Subject = string.Empty; // <-- Bu satır olmalı!
            Message = string.Empty;
        }
    }
}