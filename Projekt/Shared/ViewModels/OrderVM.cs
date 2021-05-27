using System;

using Projekt.Shared.Enums;

namespace Projekt.Shared.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientIP { get; set; }
        public int PizzaId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}