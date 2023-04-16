using System;
using System.Collections.Generic;

namespace exam.Models;

public partial class User
{
    public int Id { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Loginuser { get; set; } = null!;

    public string Passworsuser { get; set; } = null!;

    public int Idcountry { get; set; }

    public virtual Country? IdcountryNavigation { get; set; }
}
