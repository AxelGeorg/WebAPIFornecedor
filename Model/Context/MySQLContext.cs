using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace WebAPIFornecedor.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}

