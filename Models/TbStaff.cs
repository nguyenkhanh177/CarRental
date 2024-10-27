using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbStaff
{
    public int Idstaff { get; set; }

    public string StaffName { get; set; } = null!;

    public DateOnly Birth { get; set; }

    public string Idcard { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<TbMaintenanceHistory> TbMaintenanceHistories { get; set; } = new List<TbMaintenanceHistory>();
}
