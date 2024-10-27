using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbImportHistory
{
    public int Idimport { get; set; }

    public int Idsupplier { get; set; }

    public int Idcar { get; set; }

    public DateOnly Date { get; set; }

    public virtual TbCar IdcarNavigation { get; set; } = null!;

    public virtual TbSupplier IdsupplierNavigation { get; set; } = null!;
}
