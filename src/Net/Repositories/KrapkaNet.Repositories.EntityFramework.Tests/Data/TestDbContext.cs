﻿using KarpkaNet.EntityFramework.Abstractions;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Data;

public class TestDbContext(DbContextOptions options) : ApplicationDbContext(options)
{
    public DbSet<User> Users { get; set; }
}