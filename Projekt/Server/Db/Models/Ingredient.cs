using System.Collections.Generic;

namespace Projekt.Server.Db.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; } = new List<PizzaIngredient>();
    }
}