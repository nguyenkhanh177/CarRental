using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbCarReview
{
    public int IdcarReview { get; set; }

    public string Review { get; set; } = null!;

    public int Idcustomer { get; set; }

    public int Star { get; set; }
}
