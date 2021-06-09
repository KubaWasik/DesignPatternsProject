using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using Projekt.Shared.ViewModels;

namespace Projekt.Server.Functions.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderVM>
    {
        public int Id { get; set; }
    }
}