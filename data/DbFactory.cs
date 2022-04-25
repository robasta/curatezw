using System;
using Curate.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Curate.Data
{
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private Func<curatedbContext> _instanceFunc;
        private DbContext _dbContext;
        public DbContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());

        public DbFactory(Func<curatedbContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
