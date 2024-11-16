using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbBlogComment
{
    public int Idcomment { get; set; }

    public string Detail { get; set; } = null!;

    public int Idcustomer { get; set; }

    public int Idblog { get; set; }

    public DateTime Time { get; set; }

    public virtual TbBlog IdblogNavigation { get; set; } = null!;

    public virtual TbCustomer IdcustomerNavigation { get; set; } = null!;
}
