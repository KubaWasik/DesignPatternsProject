using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using Projekt.Server.Db.Models;

namespace Projekt.Server.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.Pizzas)
                .WithMany(p => p.Ingredients)
                .UsingEntity<PizzaIngredient>(
                    j => j
                        .HasOne(pi => pi.Pizza)
                        .WithMany(p => p.PizzaIngredients)
                        .HasForeignKey(pi => pi.PizzaId),
                    j => j
                        .HasOne(pi => pi.Ingredient)
                        .WithMany(i => i.PizzaIngredients)
                        .HasForeignKey(pi => pi.IngredientId)
                );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Mozzarella" },
                new Ingredient { Id = 2, Name = "Ham" },
                new Ingredient { Id = 3, Name = "Mushroom" },
                new Ingredient { Id = 4, Name = "Corn" },
                new Ingredient { Id = 5, Name = "Salami" },
                new Ingredient { Id = 6, Name = "Olives" },
                new Ingredient { Id = 7, Name = "Blue cheese" },
                new Ingredient { Id = 8, Name = "Feta" },
                new Ingredient { Id = 9, Name = "Camembert" },
                new Ingredient { Id = 10, Name = "Zucchini" },
                new Ingredient { Id = 11, Name = "Arugula " }
            );

            modelBuilder.Entity<Pizza>().
                Property(p => p.Cost)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    Id = 1,
                    Cost = 4.50M,
                    Description = "Pizza Margarita description",
                    Name = "Margarita",
                    TimeToPrepare = new System.TimeSpan(0, 15, 0)
                },
                new Pizza
                {
                    Id = 2,
                    Cost = 5.00M,
                    Description = "Pizza Funghi description",
                    Name = "Funghi",
                    TimeToPrepare = new System.TimeSpan(0, 17, 0)
                },
                new Pizza
                {
                    Id = 3,
                    Cost = 5.50M,
                    Description = "Pizza Capriciosa description",
                    Name = "Capriciosa",
                    TimeToPrepare = new System.TimeSpan(0, 18, 0)
                },
                new Pizza
                {
                    Id = 4,
                    Cost = 5.50M,
                    Description = "Pizza Salame description",
                    Name = "Salame",
                    TimeToPrepare = new System.TimeSpan(0, 18, 0)
                },
                new Pizza
                {
                    Id = 5,
                    Cost = 6.00M,
                    Description = "Pizza Vegetariana description",
                    Name = "Vegetariana",
                    TimeToPrepare = new System.TimeSpan(0, 16, 0)
                },
                new Pizza
                {
                    Id = 6,
                    Cost = 7.50M,
                    Description = "Pizza Quattro formaggi description",
                    Name = "Quattro formaggi",
                    TimeToPrepare = new System.TimeSpan(0, 20, 0)
                },
                new Pizza
                {
                    Id = 7,
                    Cost = 8.00M,
                    Description = "Pizza Deluxe description",
                    Name = "Deluxe",
                    TimeToPrepare = new System.TimeSpan(0, 20, 0)
                }
            );

            modelBuilder.Entity<PizzaIngredient>().HasData(
                // Margarita: Mozzarella
                new PizzaIngredient { Id = 1, PizzaId = 1, IngredientId = 1 },
                // Funghi: Mozzarella, Mushroom
                new PizzaIngredient { Id = 2, PizzaId = 2, IngredientId = 1 },
                new PizzaIngredient { Id = 3, PizzaId = 2, IngredientId = 3 },
                // Capriciosa: Mozzarella, Mushroom, Ham, Olives
                new PizzaIngredient { Id = 4, PizzaId = 3, IngredientId = 1 },
                new PizzaIngredient { Id = 5, PizzaId = 3, IngredientId = 2 },
                new PizzaIngredient { Id = 6, PizzaId = 3, IngredientId = 3 },
                new PizzaIngredient { Id = 7, PizzaId = 3, IngredientId = 6 },
                // Salame: Mozzarella, Salami
                new PizzaIngredient { Id = 8, PizzaId = 4, IngredientId = 1 },
                new PizzaIngredient { Id = 9, PizzaId = 4, IngredientId = 5 },
                // Vegetariana: Mozzarella, Camembert, Zucchini, Arugola
                new PizzaIngredient { Id = 10, PizzaId = 5, IngredientId = 1 },
                new PizzaIngredient { Id = 11, PizzaId = 5, IngredientId = 9 },
                new PizzaIngredient { Id = 12, PizzaId = 5, IngredientId = 10 },
                new PizzaIngredient { Id = 13, PizzaId = 5, IngredientId = 11 },
                // Quatro Formaggi: Mozzarella, Blue Cheese, Feta, Camembert
                new PizzaIngredient { Id = 14, PizzaId = 6, IngredientId = 1 },
                new PizzaIngredient { Id = 15, PizzaId = 6, IngredientId = 7 },
                new PizzaIngredient { Id = 16, PizzaId = 6, IngredientId = 8 },
                new PizzaIngredient { Id = 17, PizzaId = 6, IngredientId = 9 },
                // Deluxe: Mozzarella, Ham, Mushroom, Corn, Salami
                new PizzaIngredient { Id = 18, PizzaId = 1, IngredientId = 1 },
                new PizzaIngredient { Id = 19, PizzaId = 1, IngredientId = 2 },
                new PizzaIngredient { Id = 20, PizzaId = 1, IngredientId = 3 },
                new PizzaIngredient { Id = 21, PizzaId = 1, IngredientId = 4 },
                new PizzaIngredient { Id = 22, PizzaId = 1, IngredientId = 5 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}