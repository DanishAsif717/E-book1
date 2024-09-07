using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public string PaymentType { get; set; } = null!;

    public DateTime? PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual Order? Order { get; set; }
}
