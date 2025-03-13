using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo1.Models;

public partial class Customerordersview
{
    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? ShipName { get; set; }

    public string? ShipCity { get; set; }

    public string? City { get; set; }
}
