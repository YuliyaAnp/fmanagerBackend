using System;
using Microsoft.EntityFrameworkCore;

namespace fmanagerBackend.Models
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options): base(options)
        {
        }

        public DbSet<Transaction> Transaction { get; set; }
    }
}
