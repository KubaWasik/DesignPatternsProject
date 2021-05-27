﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt.Server.Db;

namespace Projekt.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210527074410_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projekt.Server.Db.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mozzarella"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ham"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mushroom"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Corn"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Salami"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Olives"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Blue cheese"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Feta"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Camembert"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Zucchini"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Arugula "
                        });
                });

            modelBuilder.Entity("Projekt.Server.Db.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Projekt.Server.Db.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("TimeToPrepare")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 4.50m,
                            Description = "Pizza Margarita description",
                            Name = "Margarita",
                            TimeToPrepare = new TimeSpan(0, 0, 15, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Cost = 5.00m,
                            Description = "Pizza Funghi description",
                            Name = "Funghi",
                            TimeToPrepare = new TimeSpan(0, 0, 17, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            Cost = 5.50m,
                            Description = "Pizza Capriciosa description",
                            Name = "Capriciosa",
                            TimeToPrepare = new TimeSpan(0, 0, 18, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            Cost = 5.50m,
                            Description = "Pizza Salame description",
                            Name = "Salame",
                            TimeToPrepare = new TimeSpan(0, 0, 18, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            Cost = 6.00m,
                            Description = "Pizza Vegetariana description",
                            Name = "Vegetariana",
                            TimeToPrepare = new TimeSpan(0, 0, 16, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            Cost = 7.50m,
                            Description = "Pizza Quattro formaggi description",
                            Name = "Quattro formaggi",
                            TimeToPrepare = new TimeSpan(0, 0, 20, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            Cost = 8.00m,
                            Description = "Pizza Deluxe description",
                            Name = "Deluxe",
                            TimeToPrepare = new TimeSpan(0, 0, 20, 0, 0)
                        });
                });

            modelBuilder.Entity("Projekt.Server.Db.Models.PizzaIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaIngredient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IngredientId = 1,
                            PizzaId = 1
                        },
                        new
                        {
                            Id = 2,
                            IngredientId = 1,
                            PizzaId = 2
                        },
                        new
                        {
                            Id = 3,
                            IngredientId = 3,
                            PizzaId = 2
                        },
                        new
                        {
                            Id = 4,
                            IngredientId = 1,
                            PizzaId = 3
                        },
                        new
                        {
                            Id = 5,
                            IngredientId = 2,
                            PizzaId = 3
                        },
                        new
                        {
                            Id = 6,
                            IngredientId = 3,
                            PizzaId = 3
                        },
                        new
                        {
                            Id = 7,
                            IngredientId = 6,
                            PizzaId = 3
                        },
                        new
                        {
                            Id = 8,
                            IngredientId = 1,
                            PizzaId = 4
                        },
                        new
                        {
                            Id = 9,
                            IngredientId = 5,
                            PizzaId = 4
                        },
                        new
                        {
                            Id = 10,
                            IngredientId = 1,
                            PizzaId = 5
                        },
                        new
                        {
                            Id = 11,
                            IngredientId = 9,
                            PizzaId = 5
                        },
                        new
                        {
                            Id = 12,
                            IngredientId = 10,
                            PizzaId = 5
                        },
                        new
                        {
                            Id = 13,
                            IngredientId = 11,
                            PizzaId = 5
                        },
                        new
                        {
                            Id = 14,
                            IngredientId = 1,
                            PizzaId = 6
                        },
                        new
                        {
                            Id = 15,
                            IngredientId = 7,
                            PizzaId = 6
                        },
                        new
                        {
                            Id = 16,
                            IngredientId = 8,
                            PizzaId = 6
                        },
                        new
                        {
                            Id = 17,
                            IngredientId = 9,
                            PizzaId = 6
                        },
                        new
                        {
                            Id = 18,
                            IngredientId = 1,
                            PizzaId = 1
                        },
                        new
                        {
                            Id = 19,
                            IngredientId = 2,
                            PizzaId = 1
                        },
                        new
                        {
                            Id = 20,
                            IngredientId = 3,
                            PizzaId = 1
                        },
                        new
                        {
                            Id = 21,
                            IngredientId = 4,
                            PizzaId = 1
                        },
                        new
                        {
                            Id = 22,
                            IngredientId = 5,
                            PizzaId = 1
                        });
                });

            modelBuilder.Entity("Projekt.Server.Db.Models.Order", b =>
                {
                    b.HasOne("Projekt.Server.Db.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("Projekt.Server.Db.Models.PizzaIngredient", b =>
                {
                    b.HasOne("Projekt.Server.Db.Models.Ingredient", "Ingredient")
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt.Server.Db.Models.Pizza", "Pizza")
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("Projekt.Server.Db.Models.Ingredient", b =>
                {
                    b.Navigation("PizzaIngredients");
                });

            modelBuilder.Entity("Projekt.Server.Db.Models.Pizza", b =>
                {
                    b.Navigation("PizzaIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
