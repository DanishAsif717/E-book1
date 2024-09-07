using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Descrition { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime CreatedBy { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<CdandDvd> CdandDvds { get; set; } = new List<CdandDvd>();

    public virtual ICollection<Stationary> Stationaries { get; set; } = new List<Stationary>();
}
