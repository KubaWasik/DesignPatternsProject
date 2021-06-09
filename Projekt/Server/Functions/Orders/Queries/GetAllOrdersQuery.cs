using System.Collections.Generic;

using MediatR;

using Projekt.Shared.ViewModels;

namespace Projekt.Server.Functions.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderVM>>
    {
    }
}