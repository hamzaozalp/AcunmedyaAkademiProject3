﻿namespace AcunmedyaAkademiProject3.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public Contact()
        {
            Name = string.Empty;
            Email = string.Empty;
            Subject = string.Empty;
            Message = string.Empty;
        }
    }
}