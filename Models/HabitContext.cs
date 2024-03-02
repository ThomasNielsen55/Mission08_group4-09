using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Mission08_group4_09.Models;
public partial class HabitContext : DbContext
{
    public HabitContext()
    {
    }
    public HabitContext(DbContextOptions<HabitContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ToDoList> ToDoLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Categories = "Home" },
            new Category { CategoryId = 2, Categories = "School" },
            new Category { CategoryId = 3, Categories = "Work" },
            new Category { CategoryId = 4, Categories = "Church" }
            );

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}