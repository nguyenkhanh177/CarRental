using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbBrokenCar
{
    public int IdbrokenCar { get; set; }

    public int Idcar { get; set; }

    public int Quatity { get; set; }

    public virtual TbCar IdcarNavigation { get; set; } = null!;
}
