using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class FeedbackAndQuery
{
    public int FeedbackId { get; set; }

    public int? CustomerId { get; set; }

    public string Message { get; set; } = null!;

    public string? Response { get; set; }

    public DateTime DateSubmitted { get; set; }

    public DateTime? DateResponded { get; set; }

    public virtual Customer? Customer { get; set; }
}
