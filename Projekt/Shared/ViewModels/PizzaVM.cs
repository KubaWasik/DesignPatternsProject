using System;
using System.Collections.Generic;

namespace Projekt.Shared.ViewModels
{
    public class PizzaVM
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan TimeToPrepare { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
    }
}