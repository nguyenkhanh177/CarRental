using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbCustomer
{
    public int Idcustomer { get; set; }

    public string Idcard { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string Address { get; set; } = null!;

    public DateOnly? Birth { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public virtual ICollection<TbBlogComment> TbBlogComments { get; set; } = new List<TbBlogComment>();

    public virtual ICollection<TbContract> TbContracts { get; set; } = new List<TbContract>();
}
