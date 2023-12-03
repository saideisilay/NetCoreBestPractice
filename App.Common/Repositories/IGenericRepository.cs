using System.Linq.Expressions;

namespace App.Common.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression); //IQuerable daha performanslı olması için sonradan list yaparım önce sorgu sonra listele
        //repository.where(x=>x.id>5).OrderBy.ToListAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<T> AddRangeAsync(IEnumerable<T> entities);
        IQueryable<T> AnyAsync(Expression<Func<T, bool>> expression);
        void Update(T entity);  //async değil state değiştiriyo
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
