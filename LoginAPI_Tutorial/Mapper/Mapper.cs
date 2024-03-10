using AutoMapper;
using LoginAPI_Tutorial.Entities.LoginDB;
using LoginAPI_Tutorial.Models;

namespace LoginAPI_Tutorial.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<OTP, Otp>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.UserEmail.Trim()))
                .ForMember(dest => dest.OtpcreateDate, opt => opt.MapFrom(src => src.OtpcreateDate))
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.NumOfHacks, opt => opt.MapFrom(src => src.NumOfHacks));

            CreateMap<JWT, Jwt>()
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
              .ForMember(dest => dest.Jwtid, opt => opt.MapFrom(src => src.JwtId))
              .ForMember(dest => dest.Jwttoken, opt => opt.MapFrom(src => src.JwtToken))
              .ForMember(dest => dest.ExpiryDateTime, opt => opt.MapFrom(src => src.ExpiryDateTime))
              .ForMember(dest => dest.FinalExpiryDateTime, opt => opt.MapFrom(src => src.FinalExpiryDateTime));
              
        }
    }
}

