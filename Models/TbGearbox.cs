using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbGearbox
{
    public int Idgearbox { get; set; }

    public string GearboxName { get; set; } = null!;

    public virtual ICollection<TbProductionModel> TbProductionModels { get; set; } = new List<TbProductionModel>();
}
