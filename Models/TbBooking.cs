using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbBooking
{
    public int Idbooking { get; set; }

    public int? Idcustomer { get; set; }

    public DateTime? AppointmentTime { get; set; }

    public int? Idcar { get; set; }

    public bool? IsConfirm { get; set; }

    public int? Idbranch { get; set; }

    public DateTime? BookingTime { get; set; }

    public string? Reason { get; set; }

    public virtual TbBranch? IdbranchNavigation { get; set; }

    public virtual TbCar? IdcarNavigation { get; set; }

    public virtual TbCustomer? IdcustomerNavigation { get; set; }
}
