using ApplicationCore.Common.Shared;
using ApplicationCore.Orders.Commands;
using Contracts.Order;
using Domain.OrderAggregate;
using Domain.OrderAggregate.Eitities;
using Mapster;

namespace PublicApi.Common.Mapping;

public class OrderCreateMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOrderRequest, CreateCommand>()
            .Map(dest => dest.Address, src => src.ShipToAddress);
        config.NewConfig<CreateItemRequest, ItemCommand>();

        config.NewConfig<Order, OrderResponse>()
            .Map(dest => dest.OrderId, src => src.Id.Value)
            .Map(dest => dest.PaymentRef, src => src.PaymentRef.Value)
            .Map(dest => dest.CustomerId, src => src.CustomerId.Value)
            .Map(dest => dest.Total, src => src.Total());

        config.NewConfig<Item, ItemResponse>()
            .Map(dest => dest.ItemId, src => src.Id.Value)
            .Map(dest => dest.ProductId, src => src.ProductId.Value)
            .Map(dest => dest.Currency, src => src.Price.Currency)
            .Map(dest => dest.Amount, src => src.Price.Amount);
    }
}
