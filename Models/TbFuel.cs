using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbFuel
{
    public int Idfuel { get; set; }

    public string FuelName { get; set; } = null!;

    public virtual ICollection<TbProductionModel> TbProductionModels { get; set; } = new List<TbProductionModel>();
}
