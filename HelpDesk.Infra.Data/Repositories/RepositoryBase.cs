using HelpDesk.Infra.Data.Contexto;
using HelpDesk.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HelpDesk.Infra.Data.Repositories
{
    public class RepositoryBase<TEndity> : IDisposable, IRepositoryBase<TEndity> where TEndity : class
    {
        protected HelpDeskContext Db = new HelpDeskContext();

        public void Add(TEndity obj)
        {
            Db.Set<TEndity>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEndity> GetAll()
        {
            return Db.Set<TEndity>().ToList();
        }

        public TEndity GetById(int id)
        {
            return Db.Set<TEndity>().Find(id);
        }

        public void Remove(TEndity obj)
        {
            Db.Set<TEndity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEndity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
