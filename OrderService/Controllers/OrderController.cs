using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Dtos;
using OrderService.Exceptions;
using OrderService.Interfaces;
using OrderService.Models;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderServiceFacade _facade;
    private readonly IMapper _mapper;

    public OrderController(IOrderServiceFacade facade, IMapper mapper)
    {
        _facade = facade;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto orderCreateDto)
    {
        var order = _mapper.Map<Order>(orderCreateDto);
        await _facade.CreateOrder(order);
        var orderReadDto = _mapper.Map<OrderReadDto>(order);
        return CreatedAtAction(nameof(GetOrderById), new { id = orderReadDto.Id }, orderReadDto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrders()
    {
        var orders = await _facade.GetAllOrders();
        return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orders));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderReadDto>> GetOrderById(int id)
    {
        try
        {
            var order = await _facade.GetOrderById(id);
            return Ok(_mapper.Map<OrderReadDto>(order));
        }
        catch (OrderNotFoundException)
        {
            return NotFound();
        }
    }
}
