using LoginAPI_Tutorial.Models;

namespace LoginAPI_Tutorial.Interfaces
{
    public interface ILoginService
    {
        public Task<OTPInfo> RequestLogin(LoginRequest loginRequest);
        //check otp
        //check JWT
    }
}
