using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public decimal? DistanceKm { get; set; }

    public virtual ICollection<FeedbackAndQuery> FeedbackAndQueries { get; set; } = new List<FeedbackAndQuery>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
