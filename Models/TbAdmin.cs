using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbAdmin
{
    public int Idadmin { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly Birth { get; set; }

    public string Avatar { get; set; } = null!;

    public virtual ICollection<TbBlog> TbBlogs { get; set; } = new List<TbBlog>();

    public virtual ICollection<TbContract> TbContracts { get; set; } = new List<TbContract>();
}
