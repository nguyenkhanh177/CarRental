using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbLiquidation
{
    public int Idliquidation { get; set; }

    public DateOnly DayLiquidation { get; set; }

    public decimal ClearancePrice { get; set; }

    public int Idreceiver { get; set; }

    public virtual TbReceiver IdreceiverNavigation { get; set; } = null!;
}
