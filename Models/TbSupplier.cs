using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbSupplier
{
    public int Idsupplier { get; set; }

    public string SupplierName { get; set; } = null!;

    public string Branch { get; set; } = null!;

    public virtual ICollection<TbImportHistory> TbImportHistories { get; set; } = new List<TbImportHistory>();
}
