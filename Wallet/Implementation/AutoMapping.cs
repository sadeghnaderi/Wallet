using AutoMapper;
using Wallet.Domain.Aggregates;
using Wallet.Domain.Entities;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<UserAggregate, User>();
        CreateMap<TransactionAggregate, Transaction>();

    }
}