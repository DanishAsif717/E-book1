using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class Stationary
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public int? Qty { get; set; }

    public int? CatId { get; set; }

    public DateTime? CreatedBy { get; set; }

    public virtual Category? Cat { get; set; }
}
