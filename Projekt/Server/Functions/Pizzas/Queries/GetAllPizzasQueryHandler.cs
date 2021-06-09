using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Projekt.Server.Db;
using Projekt.Shared.ViewModels;

namespace Projekt.Server.Functions.Pizzas.Queries
{
    public class GetAllPizzasQueryHandler : IRequestHandler<GetAllPizzasQuery, IEnumerable<PizzaVM>>
    {
        private readonly ApplicationDbContext context;

        public GetAllPizzasQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PizzaVM>> Handle(GetAllPizzasQuery request, CancellationToken cancellationToken)
        {
            return await context.Pizzas
                .Include(db => db.Ingredients)
                .Select(p => new PizzaVM
                {
                    Id = p.Id,
                    Cost = p.Cost,
                    Name = p.Name,
                    Description = p.Description,
                    TimeToPrepare = p.TimeToPrepare,
                    Ingredients = p.Ingredients.Select(i => i.Name).ToList().AsReadOnly()
                })
                .ToListAsync(cancellationToken);
        }
    }
}