using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbCar
{
    public int Idcar { get; set; }

    public int IdproductionModel { get; set; }

    public string Color { get; set; } = null!;

    public int ManufactureYear { get; set; }

    public virtual TbProductionModel IdproductionModelNavigation { get; set; } = null!;

    public virtual ICollection<TbBrokenCar> TbBrokenCars { get; set; } = new List<TbBrokenCar>();

    public virtual ICollection<TbContract> TbContracts { get; set; } = new List<TbContract>();

    public virtual ICollection<TbImportHistory> TbImportHistories { get; set; } = new List<TbImportHistory>();

    public virtual ICollection<TbReceiver> TbReceivers { get; set; } = new List<TbReceiver>();
}
