namespace LoginAPI_Tutorial.Models
{
    public class CompanyInfo
    {
        public string CompanyName { get; set; }
        public int CompanyID { get; set; }
        public string CompanyLogo { get; set; }
        public bool IsAdmin { get; set; }
        public int CompanyCurrency { get; set; }
        //public CompanyPaymentPlanReadDto PaymentPlan { get; set; }

        public CompanyInfo()
        {

        }

        public CompanyInfo(string CompanyName, int CompanyID, bool IsAdmin, int CompanyCurrency)
        {
            this.CompanyID = CompanyID;
            this.CompanyName = CompanyName;
            this.IsAdmin = IsAdmin;
            this.CompanyCurrency = CompanyCurrency;
        }
    }
}
