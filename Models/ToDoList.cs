using System;
using System.Collections.Generic;

namespace Mission08_group4_09.Models;

public partial class ToDoList
{
    public int TaskId { get; set; }

    public string Task { get; set; } = null!;

    public string? DueDate { get; set; }

    public int Quadrant { get; set; }

    public int? CategoryId { get; set; }

    public int? Completed { get; set; }
}
