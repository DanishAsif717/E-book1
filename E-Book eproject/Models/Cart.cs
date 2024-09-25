using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public int? Price { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
