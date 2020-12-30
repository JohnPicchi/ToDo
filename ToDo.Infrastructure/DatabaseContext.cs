using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace ToDo.Infrastructure
{
  public class DatabaseContext : DbContext
  {
    private IDbContextTransaction currentTransaction;
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {

    }

    public async Task BeginTransactionAsync()
    {
      currentTransaction ??= await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
    }

    public async Task CommitTransactionAsync()
    {
      try
      {
        await SaveChangesAsync();
        await currentTransaction.CommitAsync();
      }
      catch (Exception e)
      {
        await RollBackTransactionAsync();
        throw;
      }
      finally
      {
        if (currentTransaction != null)
        {
          await currentTransaction.DisposeAsync();
          currentTransaction = null;
        }
      }
    }

    public async Task RollBackTransactionAsync()
    {
      try
      {
        await currentTransaction.RollbackAsync();
      }
      finally
      {
        if (currentTransaction != null)
        {
          await currentTransaction.DisposeAsync();
          currentTransaction = null;
        }
      }
    }
    
    public DbSet<Models.ToDo> ToDos { get; set; }
  }
}