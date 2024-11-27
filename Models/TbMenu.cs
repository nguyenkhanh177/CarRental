using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbMenu
{
    public int Idmenu { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? Position { get; set; }

    public int? ParentMenu { get; set; }
}
