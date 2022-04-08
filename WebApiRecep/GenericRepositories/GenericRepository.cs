using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiRecep.Data;
using WebApiRecep.Entities;

namespace WebApiRecep.GenericRepositories
{
    public class GenericRepository<T, TContext> : IGenericRepository<T>
       where T : class, IEntity
       where TContext : MaliyetDbContext
    {
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        private readonly TContext _context;
        DbSet<T> Ts;

        public GenericRepository(TContext context)
        {
            _context = context;
            Ts = _context.Set<T>();

        }
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        #region CRUD (KLASİK GET,SET,POST,DELETE METOTLARI)

        public async Task<T> Get(int id)
        {
            return await Ts.FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            Ts.Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<T> Delete(int id)
        {
            var entity = await Ts.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            Ts.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            //Ts.Update(entity).State = EntityState.Modified;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        #endregion
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        #region METOT

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Count()
        {
            return Ts.Count();
        }

        public bool Save()
        {
            try
            {
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                // TODO: Log Exceptions
                return false;
            }
        }

        #endregion
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        #region FARKLI TURDEN CRUD'S 

        public async Task<List<T>> GetAll()
        {
            return await Ts.ToListAsync();
        }

        public async Task<T> AddAsyn(T t)
        {
            Ts.Add(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task<int> CountAsync()
        {
            return await Ts.CountAsync();
        }

        public virtual async Task<int> DeleteAsyn(T entity)
        {
            Ts.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return Ts.SingleOrDefault(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return Ts.Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await Ts.Where(match).ToListAsync();
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await Ts.SingleOrDefaultAsync(match);

        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Ts.Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            return await Ts.Where(predicate).ToListAsync();
        }

        public virtual async Task<ICollection<T>> GetAllAsyn()
        {
            return await Ts.ToListAsync();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {

            var query = Ts.AsQueryable();
            if (includeProperties != null)
                includeProperties.ToList().ForEach(include =>
                {
                    if (include != null)
                        query = query.Include(include);
                });
            return query;
        }

        public IQueryable<T> GetIncluding(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Ts.AsQueryable().Where(x => x.Id == id);
            if (includeProperties != null)
                includeProperties.ToList().ForEach(include =>
                {
                    if (include != null)
                        query = query.Include(include);
                });
            return query;
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await Ts.FindAsync(id);
        }

        public async virtual Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<T> UpdateAsyn(T t, object key)
        {
            if (t == null)
                return null;
            T exist = await Ts.FindAsync(key);
            if (exist != null)
            {
                //Ts.Update(exist).CurrentValues.SetValues(t);
                _context.Entry(exist).CurrentValues.SetValues(t);
                await _context.SaveChangesAsync();
            }
            return exist;
        }

        #endregion

        #region FILTER

        public IQueryable<T> Filter(Expression<Func<T, object>> order, params Expression<Func<T, bool>>[] includeProperties)
        {
            var query = Ts.AsQueryable();

            if (includeProperties != null)
                includeProperties.ToList().ForEach(include =>
                {
                    if (include != null)
                        query = query.Where(include);
                });

            return query.OrderByDescending(order);
        }

        #endregion
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

    }
}
