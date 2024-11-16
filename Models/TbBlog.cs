using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbBlog
{
    public string Title { get; set; } = null!;

    public int Idblog { get; set; }

    public string Detail { get; set; } = null!;

    public DateTime PublishTime { get; set; }

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;

    public int Idadmin { get; set; }

    public virtual TbAdmin IdadminNavigation { get; set; } = null!;

    public virtual ICollection<TbBlogComment> TbBlogComments { get; set; } = new List<TbBlogComment>();
}
