using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Projekt.Server.Db;
using Projekt.Shared.ViewModels;

namespace Projekt.Server.Functions.Orders.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderVM>
    {
        private readonly ApplicationDbContext context;

        public GetOrderByIdQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<OrderVM> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Orders
                .Where(o => o.Id == request.Id)
                .Select(o => new OrderVM
                {
                    Id = o.Id,
                    ClientIP = o.ClientIP,
                    ClientName = o.ClientName,
                    OrderDate = o.OrderDate,
                    OrderStatus = o.OrderStatus,
                    PizzaId = o.PizzaId
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}