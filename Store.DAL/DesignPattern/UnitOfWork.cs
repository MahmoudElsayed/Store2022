using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Threading.Tasks;

namespace Store.DAL
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        #region Fields

        bool _IsDisposed = false;

        public UnitOfWork(T StoreContext) => this.StoreContext = StoreContext;

        #endregion

        #region Props

        public T StoreContext { get; }
        public IDbContextTransaction DbContextTransaction { get; set; }

        public bool IsDisposed { get => _IsDisposed; }

        #endregion

        #region Methods

        public virtual void Commit() => StoreContext.Database.CurrentTransaction.Commit();

        public bool SaveChanges()
        {
            try
            {
                return StoreContext.SaveChanges() >= 0;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await StoreContext.SaveChangesAsync()) > 0;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            StoreContext.Dispose();
            _IsDisposed = true;
        }
        #endregion
    }

}
