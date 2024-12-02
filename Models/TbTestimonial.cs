using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbTestimonial
{
    public int Idtestimonial { get; set; }

    public string Name { get; set; } = null!;

    public string Profession { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public int Star { get; set; }

    public string Image { get; set; } = null!;
}
