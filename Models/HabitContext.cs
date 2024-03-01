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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("data source=Habit.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoList>(entity =>
        {
            entity.HasKey(e => e.TaskId);

            entity.ToTable("ToDoList");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
