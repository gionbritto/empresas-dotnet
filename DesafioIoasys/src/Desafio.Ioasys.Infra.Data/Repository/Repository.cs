using Desafio.Ioasys.Domain.Interfaces.Repository;
using Desafio.Ioasys.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Ioasys.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DesafioIOContext _db;
        protected DbSet<TEntity> _dbSet;

        public Repository(DesafioIOContext context)
        {
            _db = context;
            _dbSet = _db.Set<TEntity>();
        }

        public async Task<TEntity> Adicionar(TEntity obj)
        {
            var t = await _dbSet.AddAsync(obj);
            return t.Entity;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var objUpdated = _dbSet.Update(obj);
            return objUpdated.Entity;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void DetachLocal(Func<TEntity, bool> predicate)
        {
            var local = _dbSet.Local.Where(predicate).FirstOrDefault();
            if (local != null)
            {
                _db.Entry(local).State = EntityState.Detached;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public void Remover(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

    }
}
