using System.ComponentModel.DataAnnotations;

namespace FCES.Models
{
    public class Certificates
    {
        [Key]
        public string CertificateNo { get; set; }

        public DateTime IssueDate { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Method { get; set; }
        public string Level { get; set; }

        public int GeneralMarks { get; set; }      
        public int SpecificMarks { get; set; }     
        public int PracticalMarks { get; set; }    
        public int Total { get; set; }             
        public int Percentage { get; set; }        

        public string NearVision { get; set; }
        public string ColorBlindness { get; set; }

        public int TrainingHours { get; set; }     

        public string ImagePath { get; set; }
    }
}
