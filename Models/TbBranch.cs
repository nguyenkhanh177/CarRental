using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbBranch
{
    public int Idbranch { get; set; }

    public string? NameBranch { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<TbBooking> TbBookings { get; set; } = new List<TbBooking>();
}
