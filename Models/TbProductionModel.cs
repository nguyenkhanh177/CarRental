using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbProductionModel
{
    public int IdproductionModel { get; set; }

    public int Idautomaker { get; set; }

    public int SeatingCapacity { get; set; }

    public int Idgearbox { get; set; }

    public int Idfuel { get; set; }

    public string Describe { get; set; } = null!;

    public int Star { get; set; }

    public int IddriverCapabilities { get; set; }

    public string ProductionModelName { get; set; } = null!;

    public virtual TbAutomaker IdautomakerNavigation { get; set; } = null!;

    public virtual TbDriverCapability IddriverCapabilitiesNavigation { get; set; } = null!;

    public virtual TbFuel IdfuelNavigation { get; set; } = null!;

    public virtual TbGearbox IdgearboxNavigation { get; set; } = null!;

    public virtual ICollection<TbCar> TbCars { get; set; } = new List<TbCar>();
}
