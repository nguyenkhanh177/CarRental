﻿using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbReceiver
{
    public int Idreceiver { get; set; }

    public string NameReceiver { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Gmail { get; set; } = null!;

    public virtual ICollection<TbLiquidation> TbLiquidations { get; set; } = new List<TbLiquidation>();
}
