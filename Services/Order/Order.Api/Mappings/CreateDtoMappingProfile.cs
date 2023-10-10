using AutoMapper;
using Order.Application.Dto.Order;
using Order.Application.Dto.OrderItem;
using Order.Application.Dto.OrderStatusHistory;
using Order.Application.Dto.ShippingDetails;
using Order.Core.Entities;

namespace Order.Api.Mappings
{
    public class CreateDtoMappingProfile : Profile
    {
        public CreateDtoMappingProfile()
        {
            CreateMap<CreateOrderDto, Core.Entities.Order>();
            CreateMap<CreateOrderItemDto, OrderItem>();
            CreateMap<CreateOrderStatusHistoryDto, OrderStatusHistory>();
            CreateMap<CreateShippingDetailsDto, ShippingDetails>();
        }
    }
}

