namespace LoginAPI_Tutorial.Models
{
    public class ValidateResponse
    {
        public List<CompanyInfo> CompaniesInfo  { get; set; }
        public string JwtToken { get; set; }
        public long UserId { get; set; }
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ValidateResponse(List<CompanyInfo> companyInfos, string Jwttoken, long UserId, string FirstName, string LastName)
        {
            this.CompaniesInfo = companyInfos;
            this.JwtToken = Jwttoken;
            this.UserId = UserId;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public ValidateResponse(List<CompanyInfo> companyInfos, string Jwttoken, long UserId, string FirstName, string LastName, string UserEmail)
        {
            this.CompaniesInfo = companyInfos;
            this.JwtToken = Jwttoken;
            this.UserId = UserId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserEmail = UserEmail;
        }
        public ValidateResponse(string Jwttoken)
        {
            this.JwtToken = Jwttoken;
        }
        public ValidateResponse()
        {

        }
    }
}
