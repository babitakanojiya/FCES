using Microsoft.AspNetCore.Mvc;

namespace FCES.Models
{
    public class ContactFormModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string InterestedCourse { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
