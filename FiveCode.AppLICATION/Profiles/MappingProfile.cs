using AutoMapper;
using FiveCode.Application.Features.Payment.Command;

namespace FiveCode.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Payment, CreatePaymentCommand>().ReverseMap();
            CreateMap<Domain.PaymentHistory, Dtos.PaymenHistoryCreationDto>().ReverseMap();
        }
    }
}