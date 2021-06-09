using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Projekt.Server.Db;
using Projekt.Shared.ViewModels;

namespace Projekt.Server.Functions.Pizzas.Queries
{
    public class GetPizzaByIdQueryHandler : IRequestHandler<GetPizzaByIdQuery, PizzaVM>
    {
        private readonly ApplicationDbContext context;

        public GetPizzaByIdQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<PizzaVM> Handle(GetPizzaByIdQuery request, CancellationToken cancellationToken)
        {
            return await context.Pizzas
                .Include(db => db.Ingredients)
                .Where(p => p.Id == request.Id)
                .Select(p => new PizzaVM
                {
                    Id = p.Id,
                    Cost = p.Cost,
                    Description = p.Description,
                    TimeToPrepare = p.TimeToPrepare,
                    Ingredients = p.Ingredients.Select(i => i.Name).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}