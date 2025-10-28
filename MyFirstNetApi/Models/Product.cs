using System;
using System.Collections.Generic;

namespace MyFirstNetApi.Models;

public partial class Product
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime? ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public string? CustomerId { get; set; }
}
