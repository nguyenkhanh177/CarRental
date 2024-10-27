using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TbBlog
{
    public string? Title { get; set; }

    public int BlogId { get; set; }

    public string? Detail { get; set; }

    public DateTime? PublishTime { get; set; }

    public virtual ICollection<TbBlogComment> TbBlogComments { get; set; } = new List<TbBlogComment>();
}
