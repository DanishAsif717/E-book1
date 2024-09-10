using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class CdandDvd
{
    public int Id { get; set; }

    public string Author { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string Lounch { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;

    public int CatId { get; set; }

    public DateTime CreatedBy { get; set; }

    public virtual Category Cat { get; set; } = null!;
}
