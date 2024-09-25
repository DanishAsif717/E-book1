using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Image { get; set; }

    public string? Password { get; set; }

    public int? Role { get; set; }

    public string? ConfirmPassword { get; set; }

    public DateTime? CreatedBy { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
