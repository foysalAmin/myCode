using ApplicationCore.Customers.Command;
using Contracts.Customer;
using Mapster;

namespace PublicApi.Common.Mapping;

public class CustomerCreateMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCustomerRequest, CreateCommand>()
            .Map(dest => dest.Address, src => src.Address);
    }
}
