namespace LoginAPI_Tutorial.Models
{
    public class JWT
    {
        public string JwtToken { get; set; }
        public long UserId { get; set; }
        public int JwtId { get; set; }
        public DateTime ExpiryDateTime { get; set; }
        public DateTime FinalExpiryDateTime { get; set; }

        public JWT()
        {

        }
        public JWT(string Jwttoken, long UserId)
        {
            this.JwtToken = Jwttoken;
            this.UserId = UserId;
            this.ExpiryDateTime = DateTime.Now.AddMinutes(30);
            this.FinalExpiryDateTime = DateTime.Now.AddHours(3);
        }

        public JWT(string Jwttoken)
        {
            this.JwtToken = Jwttoken;
            this.ExpiryDateTime = DateTime.Now.AddMinutes(30);
            this.FinalExpiryDateTime = DateTime.Now.AddHours(3);
        }
    }
}
