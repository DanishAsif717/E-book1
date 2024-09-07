using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string SubCategory { get; set; } = null!;

    public int? ManufacturerId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? Version { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
