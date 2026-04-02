namespace FCES.Models
{
    public class Certificate_Verification
    {
        public int Id { get; set; }
        public string CertificateNo { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }
        public string Level { get; set; }
        public int GeneralMarks { get; set; }
        public int SpecificMarks { get; set; }
        public int PracticalMarks { get; set; }
        public int Total { get; set; }
        public int Percentage { get; set; }
        public string ImagePath { get; set; }
    }
}
