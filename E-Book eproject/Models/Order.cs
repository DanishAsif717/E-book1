using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public int? CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal? DeliveryDistance { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
