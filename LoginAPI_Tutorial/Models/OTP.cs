namespace LoginAPI_Tutorial.Models
{
    public class OTP
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string Guid { get; set; }
        public DateTime OtpcreateDate { get; set; }
        public int NumOfHacks { get; set; }

        public OTP(string userId,string userEmail)
        {
            UserId = userId;
            UserEmail = userEmail;
            OtpcreateDate = DateTime.Now;
            NumOfHacks = 0;
            Password = GenerateOTP();
            Guid = System.Guid.NewGuid().ToString();
        }


        private string GenerateOTP()
        {
            Random generator = new Random();
            return generator.Next(0, 1000000).ToString("D6");             
        }
    }
}
