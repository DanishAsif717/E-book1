using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class SubCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Code { get; set; } = null!;

    public int CatId { get; set; }

    public DateTime? CreatedBy { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Category Cat { get; set; } = null!;

    public virtual ICollection<CdandDvd> CdandDvds { get; set; } = new List<CdandDvd>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
