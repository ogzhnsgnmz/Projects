﻿using Microsoft.EntityFrameworkCore;
using OrderAPI.Models.Entities;

namespace OrderAPI.Models;

public class OrderAPIDbContext:DbContext
{
    public OrderAPIDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}
