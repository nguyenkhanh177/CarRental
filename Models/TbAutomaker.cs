using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbAutomaker
{
    public int Idautomaker { get; set; }

    public string AutomakerName { get; set; } = null!;

    public virtual ICollection<TbProductionModel> TbProductionModels { get; set; } = new List<TbProductionModel>();
}
