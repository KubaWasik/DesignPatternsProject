using System.Collections.Generic;

using MediatR;

using Projekt.Shared.ViewModels;

namespace Projekt.Server.Functions.Pizzas.Queries
{
    public class GetAllPizzasQuery : IRequest<IEnumerable<PizzaVM>>
    {
    }
}