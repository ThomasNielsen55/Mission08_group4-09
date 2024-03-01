using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission08_group4_09.Models;

public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    public string Categories { get; set; } = null!;
}
