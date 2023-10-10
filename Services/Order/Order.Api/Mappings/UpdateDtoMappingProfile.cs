using AutoMapper;
using Order.Application.Dto.Order;
using Order.Application.Dto.OrderItem;
using Order.Application.Dto.OrderStatusHistory;
using Order.Application.Dto.ShippingDetails;
using Order.Core.Entities;

namespace Order.Api.Mappings
{
    public class UpdateDtoMappingProfile : Profile
    {
        public UpdateDtoMappingProfile()
        {
            CreateMap<UpdateOrderDto, Core.Entities.Order>();
            CreateMap<UpdateOrderItemDto, OrderItem>();
            CreateMap<UpdateOrderStatusHistoryDto, OrderStatusHistory>();
            CreateMap<UpdateShippingDetailsDto, ShippingDetails>();
        }
    }
}
