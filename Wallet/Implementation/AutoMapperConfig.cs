using Wallet.Domain.Aggregates;
using Wallet.Domain.Entities;

namespace Wallet.Implementation
{
    public static class AutoMapperConfig
    {
        private static int m = 0;
        public static void Configure()
        {
            if (m == 0)
            {
                m++;
                MapperWrapper.Initialize(cfg =>
                {
                    cfg.CreateMap<UserAggregate, User>();
                    cfg.CreateMap<TransactionAggregate, Transaction>();

                });

                MapperWrapper.AssertConfigurationIsValid();
            }
        }
    }
}
