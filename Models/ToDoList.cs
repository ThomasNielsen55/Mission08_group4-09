using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_group4_09.Models;

public partial class ToDoList
{
    [Key]
    public int TaskId { get; set; }

    public string Task { get; set; } = null!;

    public string? DueDate { get; set; }

    public int Quadrant { get; set; }

    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public int? Completed { get; set; }
}
