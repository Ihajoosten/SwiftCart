using AutoMapper;
using Order.Application.Dto.Order;
using Order.Application.Dto.OrderItem;
using Order.Application.Dto.OrderStatusHistory;
using Order.Application.Dto.ShippingDetails;
using Order.Core.Entities;

namespace Order.Api.Mappings
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Core.Entities.Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderStatusHistory, OrderStatusHistoryDto>();
            CreateMap<ShippingDetails, ShippingDetailsDto>();
        }
    }
}

