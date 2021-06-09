using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

namespace Projekt.Server.Functions.Orders.Commands
{
    public class AddOrderQuery : IRequest<int>
    {
        public int PizzaId { get; set; }
        public string ClientName { get; set; }
        public string ClinetIP { get; set; }
    }
}