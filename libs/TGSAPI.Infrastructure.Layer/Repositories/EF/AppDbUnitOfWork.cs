using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TGS.Infra.Core.EF.Contracts;
using TGSAPI.Persistence.Layer.EF;

namespace TGSAPI.Infrastructure.Layer.Repositories.EF
{
  public class AppDbUnitOfWork : IUnitOfwork
  {
    private readonly AppDbContext appDb;
    private readonly ILogger<AppDbUnitOfWork> logger;

    public AppDbUnitOfWork(AppDbContext appDbContext, ILogger<AppDbUnitOfWork> logger)
    {
      appDb = appDbContext;
      this.logger = logger;
    }

    public async Task<int> CommitAsync()
    {
      using (var tran = await appDb.Database.BeginTransactionAsync())
      {
        try
        {
          // change Trackerdan önceki state
          var entries = appDb.ChangeTracker.Entries().Select(a=> new {Entity = a.Entity,State=a.State}).ToList();

          var results = await appDb.SaveChangesAsync();
          await tran.CommitAsync();


          if (results > 0)
          {
   
            entries.ToList().ForEach((item) =>
            {


              if (item.State == Microsoft.EntityFrameworkCore.EntityState.Added)
              {
                // @entity @ ile yazılan template'i direkt object olarak loga atılır. 

                this.logger.LogInformation("Insert Gerçekleşti  {@entity}", item.Entity);
              }
              else if (item.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
              {
                this.logger.LogInformation("Update Gerçekleşti  {@entity}", item.Entity);
              }
              else if (item.State == Microsoft.EntityFrameworkCore.EntityState.Deleted)
              {
                this.logger.LogInformation("Delete Gerçekleşti  {@entity}", item.Entity);
              }

            });

          }

          // Db Success Log
          return results;
        }
        catch (Exception) // DbException varsa burada yakalınır.
        {
          await tran.RollbackAsync();
          this.logger.LogInformation("Kayıt Rollback");

          return 0;
        }
      }


    }
  }
}
