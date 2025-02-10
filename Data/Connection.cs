﻿using Microsoft.EntityFrameworkCore;

namespace Data;

public class Connection : DbContext
{
    public DbSet<Client> Clients { get; set; }
    
    public Connection(DbContextOptions<Connection> options) : base(options)
    {
        
    }


}
