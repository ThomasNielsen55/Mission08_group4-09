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
        modelBuilder.Entity<ToDoList>().HasData(
            new ToDoList { TaskId = 1, Task = "Home" },
            new ToDoList { TaskId = 2, Task = "School" },
            new ToDoList { TaskId = 3, Task = "Work" },
            new ToDoList { TaskId = 4, Task = "Church" }
            );

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}