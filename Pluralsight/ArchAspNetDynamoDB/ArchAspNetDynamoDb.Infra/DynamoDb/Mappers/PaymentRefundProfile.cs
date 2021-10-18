using ArchAspNetDynamoDb.Domain.Models.Entities;
using ArchAspNetDynamoDb.Infra.DynamoDb.Models;
using AutoMapper;

namespace ArchAspNetDynamoDb.Infra.DynamoDb.Mappers
{
    public class PaymentRefundProfile : Profile
    {
        public PaymentRefundProfile() : base()
        {
            CreateMap<PaymentRefund, DynamoPaymentRefund>()
               .ForMember(destination => destination.PaymentId, cfg => cfg.MapFrom(source => source.PaymentId))
               ;

            CreateMap<DynamoPaymentRefund, PaymentRefund>()
                 .ForMember(destination => destination.PaymentId, cfg => cfg.MapFrom(source => source.PaymentId))
                ;

            CreateMap<Domain.Models.ValueObjects.Person, Models.Person>();
            CreateMap<Models.Person, Domain.Models.ValueObjects.Person>();

            CreateMap<Domain.Models.ValueObjects.Bank, Models.Bank>();
            CreateMap<Models.Bank, Domain.Models.ValueObjects.Bank>();
        }
    }
}