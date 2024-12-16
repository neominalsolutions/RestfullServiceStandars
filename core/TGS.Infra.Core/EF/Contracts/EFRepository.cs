using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TGS.Domain.Core.Contracts;

namespace TGS.Infra.Core.EF.Contracts
{
  public abstract class EFRepository<TDbContext, TEntity, TKey> : IRepository<TEntity, TKey>
    where TDbContext : DbContext
    where TEntity : Entity<TKey>
    where TKey : IComparable
  {
    protected readonly TDbContext dbContext; // database
    protected readonly DbSet<TEntity> dbSet; // table

    protected EFRepository(TDbContext dbContext)
    {
      this.dbContext = dbContext;
      this.dbSet = dbContext.Set<TEntity>();
    }


    public virtual async Task CreateAsync(TEntity entity)
    {
       await this.dbSet.AddAsync(entity);
    }

    public virtual async Task DeleteAsync(TKey Id)
    {

     var task =  Task.Run(() =>
      {
        var entity = dbSet.Find(Id);
        ArgumentNullException.ThrowIfNull(entity);

        dbSet.Remove(entity);

      });


      await task;
    }

    public virtual async Task<IEnumerable<TEntity>> FindAsync()
    {

      return (await dbSet.AsNoTracking().ToListAsync());
    }

    public virtual  IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
    {
      return dbSet.AsNoTracking().Where(expression).AsQueryable();
    }

    public virtual async Task<TEntity> FindByIdAsync(TKey Id)
    {
      var entity = await  dbSet.FirstOrDefaultAsync(x=> x.Id.Equals(Id));
      ArgumentNullException.ThrowIfNull(entity);

      return entity;
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
      var task = Task.Run(() => dbSet.Update(entity));

      await task;
    }
  }
}
