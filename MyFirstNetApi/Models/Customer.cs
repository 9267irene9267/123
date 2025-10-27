using System;
using System.Collections.Generic;

namespace MyFirstNetApi.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateOnly? CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateOnly? ModifyDate { get; set; }

    public string? ModifyUser { get; set; }
}
