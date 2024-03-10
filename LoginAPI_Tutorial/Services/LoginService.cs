using AutoMapper;
using LoginAPI_Tutorial.Entities.LoginDB;
using LoginAPI_Tutorial.Interfaces;
using LoginAPI_Tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using static LoginAPI_Tutorial.Constants.Consts;

namespace LoginAPI_Tutorial.Services
{
    public class LoginService : ILoginService
    {
        private readonly LoginDbContext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly INotificationService _notification;
        public LoginService(IConfiguration config, LoginDbContext context, IMapper mapper, INotificationService notification)
        {
            _config = config;
            _context = context;
            _mapper = mapper;
            _notification = notification;
        }

        public async Task<OTPInfo> RequestLogin(LoginRequest loginRequest)
        {
            //check if user exists
            var user = await _context.Users.Join(_context.UserEmails, u => u.UserId, ue => ue.UserId, (u, ue) => new { u, ue })
                .Where(x => x.u.PersonalIdnumber == loginRequest.LoginID && x.ue.UserEmail1 == loginRequest.Email)
                .Select(x => x.u.UserId).FirstOrDefaultAsync();
            var user123 = await _context.Users.Select(x => x.UserId).FirstOrDefaultAsync();

            // delete old OTP
            await DeleteOTP(user);

            if (user != default)
            {
                var otp = new OTP(user.ToString(), loginRequest.Email);
                try
                {
                    var _otp = _mapper.Map<Otp>(otp);
                    await _context.Otps.AddAsync(_otp);
                    await _context.SaveChangesAsync();

                    if (_otp?.Password.Length > 0)
                    {
                        if (await _notification.SendEmailAsync(loginRequest.Email, _otp.Password))
                            return new OTPInfo() { Guid = otp.Guid };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return null;
        }

        public async Task DeleteOTP(long userId)
        {
            _context.Otps.RemoveRange(_context.Otps.Where(x => x.UserId == userId));
            await _context.SaveChangesAsync();
        }
        public async Task<ValidateResponse> ValidateOTP(OTPDetails otpRequest)
        {
            try
            {
                var otp = await _context.Otps.Where(x => x.Guid == otpRequest.Guid).FirstOrDefaultAsync();
                if (otp == null || otp.NumOfHacks > 5) return null;
                if (otp.Password != otpRequest.OTPNumber)
                {
                    otp.NumOfHacks++;
                    await _context.SaveChangesAsync();
                    return null;
                }
                if (otp.OtpcreateDate.AddMinutes(5) <= DateTime.Now)
                {
                    await DeleteOTP(otp.UserId);
                    return null;
                }

                await DeleteJWT(otp.UserId);

                List<CompanyInfo> companyInfos = await (from x in _context.UserCompanyConnections
                                                        join y in _context.Companies on x.RelatedCompanyId equals y.CompanyId
                                                        where x.UserId == otp.UserId && x.IsActive == true
                                                        select new CompanyInfo(y.CompanyLegalName, (int)(y.CompanyId),
                                                        y.CompanyAdminUserId == otp.UserId ? true : false, y.Currency)).ToListAsync();

                StringBuilder UserIDAndCompList = new StringBuilder(otp.UserId.ToString());
                UserIDAndCompList.Append(";");
                if (companyInfos != null)
                {
                    foreach (var compInfo in companyInfos)
                    {
                        UserIDAndCompList.Append(compInfo.CompanyID);
                        UserIDAndCompList.Append(";");

                    }
                }

                string token = Authenticate(UserIDAndCompList.ToString());
                var jwt = new JWT(token, otp.UserId);
                var _jwt = _mapper.Map<Jwt>(jwt);
                await _context.Jwts.AddAsync(_jwt);
                await _context.SaveChangesAsync();

                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId.Equals(otp.UserId));
                ValidateResponse vr = new ValidateResponse(companyInfos, _jwt.Jwttoken, otp.UserId, user.FirstName, user.LastName);
                return vr;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task DeleteJWT(long userId)
        {
            _context.Jwts.RemoveRange(_context.Jwts.Where(x => x.UserId == userId));
            await _context.SaveChangesAsync();
        }

        public  string Authenticate(string claimData)
        {
            var key = _config[ConfiguationKeys.SIGNING_KEY];
            var tokenKey  = Encoding.ASCII.GetBytes(key);   
            var tokenDesc =  new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, claimData),
                    new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddMinutes(5).ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
