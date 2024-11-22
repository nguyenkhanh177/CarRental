using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbDriverCapability
{
    public int IddriverCapabilities { get; set; }

    public string DriverCapabilitiesName { get; set; } = null!;

    public virtual ICollection<TbProductionModel> TbProductionModels { get; set; } = new List<TbProductionModel>();
}
