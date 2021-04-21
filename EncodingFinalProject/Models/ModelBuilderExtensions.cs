using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EncodingFinalProject.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "computer science" },
                new Category { Id = 2, Name = "math" },
                new Category { Id = 3, Name = "physics" },
                new Category { Id = 4, Name = "chemistry" },
                new Category { Id = 5, Name = "biology" });

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, CategoryId = 1, Name = "c# introduction", Sku = "AWMGSJ", Price = 68, IsAvailable = true },
                new Course { Id = 2, CategoryId = 1, Name = "statistics", Sku = "AWMPS", Price = 35, IsAvailable = true },
                new Course { Id = 3, CategoryId = 1, Name = "laws of motion", Sku = "AWMSGT", Price = 33, IsAvailable = true },
                new Course { Id = 4, CategoryId = 1, Name = "molucular formula", Sku = "AWMSJ", Price = 125, IsAvailable = true },
                new Course { Id = 5, CategoryId = 1, Name = "human wellbeing", Sku = "AWMTFJ", Price = 60, IsAvailable = true },
                new Course { Id = 6, CategoryId = 1, Name = "python for everyone", Sku = "AWMUTV", Price = 95, IsAvailable = true },
                new Course { Id = 7, CategoryId = 1, Name = "probability", Sku = "AWMVNP", Price = 65, IsAvailable = true },
                new Course { Id = 8, CategoryId = 1, Name = "hydraulics", Sku = "AWMVNS", Price = 65, IsAvailable = true },
                new Course { Id = 9, CategoryId = 1, Name = "atoms and particles", Sku = "AWMVNT", Price = 17, IsAvailable = true },
                new Course { Id = 10, CategoryId = 2, Name = "environmental care", Sku = "AWWBTSC", Price = 99, IsAvailable = true });
                  

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "adam@example.com" },
                new User { Id = 2, Email = "barbara@example.com" });
        }
    }
}
