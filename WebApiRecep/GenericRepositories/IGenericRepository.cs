using System.Linq.Expressions;
using WebApiRecep.Entities;

namespace WebApiRecep.GenericRepositories
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        #region CRUD (KLASİK GET,SET,POST,DELETE METOTLARI)

        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);


        #endregion
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        #region METOT

        void Dispose();
        int Count();
        bool Save();

        #endregion
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        #region FARKLI TURDEN CRUD'S 

        Task<T> AddAsyn(T t);
        Task<List<T>> GetAll();
        Task<int> CountAsync();
        Task<int> DeleteAsyn(T entity);
        T Find(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> GetAllAsyn();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetIncluding(int id, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(int id);
        Task<int> SaveAsync();
        Task<T> UpdateAsyn(T t, object key);

        #endregion

        #region FILTER

        IQueryable<T> Filter(Expression<Func<T, object>> order, params Expression<Func<T, bool>>[] includeProperties);

        #endregion
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
    }
}
