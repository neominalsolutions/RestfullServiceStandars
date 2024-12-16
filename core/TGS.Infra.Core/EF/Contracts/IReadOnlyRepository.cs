using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TGS.Domain.Core.Contracts;

namespace TGS.Infra.Core.EF.Contracts
{
  public interface IReadOnlyRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TKey : IComparable
  {
    /// <summary>
    /// Veritabanından tüm kayıtları çeker. Bu sebeple async tanımlamak non-blocing çalışma sağlar.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> FindAsync(); 

    /// <summary>
    /// veritabanına gönderilmeden önceki sorgu  formatı bu sebeple, IQuerable tipinde ve sync tanımlı
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression); 
    Task<TEntity> FindByIdAsync(TKey Id);


  }
}
