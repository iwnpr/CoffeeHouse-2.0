using AutoMapper;
using OrderService.Dtos;
using OrderService.Models;

namespace OrderService.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderReadDto>();
        CreateMap<OrderCreateDto, Order>();
        CreateMap<OrderItem, OrderItemReadDto>();
        CreateMap<OrderItemCreateDto, OrderItem>();
    }
}