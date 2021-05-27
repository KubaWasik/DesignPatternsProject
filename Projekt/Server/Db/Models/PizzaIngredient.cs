namespace Projekt.Server.Db.Models
{
    public class PizzaIngredient
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}