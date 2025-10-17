using System;
using System.Collections.Generic;

namespace MyFirstNetApi.Models;

public partial class Product
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public string? Description { get; set; }

    public DateTime? Createdate { get; set; }

    public string? Createuser { get; set; }

    public DateTime? Modifydate { get; set; }

    public string? Modifyuser { get; set; }
}
