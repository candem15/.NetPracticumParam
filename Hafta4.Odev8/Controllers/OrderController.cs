using AutoMapper;
using Hafta4.Odev8.Application.OrderOperations.Commands.CreateOrder;
using Hafta4.Odev8.Application.OrderOperations.Commands.DeleteOrder;
using Hafta4.Odev8.Application.OrderOperations.Commands.UpdateOrder;
using Hafta4.Odev8.Application.OrderOperations.Queries.GetOrderDetails;
using Hafta4.Odev8.Application.OrderOperations.Queries.GetOrders;
using Hafta4.Odev8.DbOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Hafta4.Odev8.Application.OrderOperations.Commands.CreateOrder.CreateOrderCommand;
using static Hafta4.Odev8.Application.OrderOperations.Commands.UpdateOrder.UpdateOrderCommand;

namespace Hafta4.Odev8.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetLists()
        {
            GetOrdersQuery query = new GetOrdersQuery(_dbContext, _mapper);
            var response = query.Handle();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            GetOrderDetailsQuery query = new GetOrderDetailsQuery(_dbContext, _mapper);
            query.OrderId = id;


            var response = query.Handle();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderModel model)
        {
            CreateOrderCommand command = new CreateOrderCommand(_dbContext, _mapper);
            command.Model = model;


            command.Handle();

            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromBody] UpdateOrderModel model, int Id)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_dbContext, _mapper);
            command.Model = model;
            command.OrderId = Id;

            command.Handle();

            return Ok();
        }

        [HttpPut("delete/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_dbContext);

            command.OrderId = Id;
            command.Handle();

            return Ok();
        }
    }
}
