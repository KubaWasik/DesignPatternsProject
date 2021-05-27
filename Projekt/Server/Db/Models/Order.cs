using System;

using Projekt.Shared.Enums;

namespace Projekt.Server.Db.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientIP { get; set; }
        public int PizzaId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual Pizza Pizza { get; set; }
    }
}