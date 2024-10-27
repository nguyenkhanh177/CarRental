using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbContract
{
    public int Idcontract { get; set; }

    public int Idcustomer { get; set; }

    public int Idcar { get; set; }

    public DateOnly RentalDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal ContractPrice { get; set; }

    public string Status { get; set; } = null!;

    public int? Idadmin { get; set; }

    public virtual TbAdmin? IdadminNavigation { get; set; }

    public virtual TbCar IdcarNavigation { get; set; } = null!;

    public virtual TbCustomer IdcustomerNavigation { get; set; } = null!;

    public virtual ICollection<TbMaintenanceHistory> TbMaintenanceHistories { get; set; } = new List<TbMaintenanceHistory>();
}
