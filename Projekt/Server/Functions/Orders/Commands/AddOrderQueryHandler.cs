using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Projekt.Server.Db;
using Projekt.Server.Db.Models;
using Projekt.Shared.Enums;

namespace Projekt.Server.Functions.Orders.Commands
{
    public class AddOrderQueryHandler : IRequestHandler<AddOrderQuery, int>
    {
        private readonly ApplicationDbContext context;

        public AddOrderQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(AddOrderQuery request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                ClientIP = request.ClinetIP,
                ClientName = request.ClientName,
                OrderDate = DateTime.Now,
                OrderStatus = OrderStatus.Created,
                PizzaId = request.PizzaId
            };

            context.Orders.Add(order);

            await context.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}