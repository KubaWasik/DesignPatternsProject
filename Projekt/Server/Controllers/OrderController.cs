using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Projekt.Server.Functions.Orders.Commands;
using Projekt.Server.Functions.Orders.Queries;
using Projekt.Shared.ViewModels;

namespace Projekt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetOrder")]
        public async Task<OrderVM> GetOrder(int orderId)
        {
            var order = await mediator.Send(new GetOrderByIdQuery { Id = orderId });

            return order;
        }

        [HttpPost("AddOrder")]
        public async Task<int> AddOrder([FromBody] AddOrderVM orderVM)
        {
            orderVM.ClientIP = HttpContext.Connection.RemoteIpAddress.ToString();

            var id = await mediator.Send(
                new AddOrderQuery
                {
                    ClientName = orderVM.ClientName,
                    ClinetIP = orderVM.ClientIP,
                    PizzaId = orderVM.PizzaId
                });

            return id;
        }
    }
}