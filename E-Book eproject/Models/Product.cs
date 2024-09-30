using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Author { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public string? Lounch { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Stock { get; set; }

    public int CatId { get; set; }

    public int SubId { get; set; }

    public DateTime CreatedBy { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Cat { get; set; } = null!;

    public virtual SubCategory Sub { get; set; } = null!;
}
