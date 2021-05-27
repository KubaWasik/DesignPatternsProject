using System.Collections.Generic;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Projekt.Server.Functions.Pizzas.Queries;
using Projekt.Shared.ViewModels;

namespace Projekt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IMediator mediator;

        public PizzaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<PizzaVM> Get(int id)
        {
            return await mediator.Send(new GetPizzaByIdQuery { Id = id });
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<PizzaVM>> GetAll()
        {
            return await mediator.Send(new GetAllPizzasQuery());
        }
    }
}