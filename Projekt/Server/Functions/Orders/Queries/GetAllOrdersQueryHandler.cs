using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Projekt.Server.Db;
using Projekt.Shared.ViewModels;

namespace Projekt.Server.Functions.Orders.Queries
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderVM>>
    {
        private readonly ApplicationDbContext context;

        public GetAllOrdersQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<OrderVM>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await context.Orders
                .Select(o => new OrderVM
                {
                    Id = o.Id,
                    ClientIP = o.ClientIP,
                    ClientName = o.ClientName,
                    OrderDate = o.OrderDate,
                    OrderStatus = o.OrderStatus,
                    PizzaId = o.PizzaId
                })
                .ToListAsync(cancellationToken);
        }
    }
}