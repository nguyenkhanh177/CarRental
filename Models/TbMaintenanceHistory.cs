using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbMaintenanceHistory
{
    public int Idmaintenance { get; set; }

    public int Idstaff { get; set; }

    public int Idcontract { get; set; }

    public DateOnly MaintenanceDay { get; set; }

    public virtual TbContract IdcontractNavigation { get; set; } = null!;

    public virtual TbStaff IdstaffNavigation { get; set; } = null!;
}
