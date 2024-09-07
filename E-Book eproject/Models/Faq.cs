using System;
using System.Collections.Generic;

namespace E_Book_eproject.Models;

public partial class Faq
{
    public int Faqid { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;
}
