using MediatR;

using Projekt.Shared.ViewModels;

namespace Projekt.Server.Functions.Pizzas.Queries
{
    public class GetPizzaByIdQuery : IRequest<PizzaVM>
    {
        public int Id { get; set; }
    }
}