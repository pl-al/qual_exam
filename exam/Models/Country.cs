using System;
using System.Collections.Generic;

namespace exam.Models;

public partial class Country
{
    public int Id { get; set; }

    public string? Country1 { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
