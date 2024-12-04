using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbNotificalAdmin
{
    public int Idnotifical { get; set; }

    public string? Detail { get; set; }

    public DateTime? Time { get; set; }
}
