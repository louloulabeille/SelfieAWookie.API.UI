using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using SelfieAWookie.Core.Selfies.Interface.Infrastructure;
using SelfieAWookie.Core.Selfies.Interface.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructure.DataLayers
{
    public class SqlServerSelfieDataLayer : BaseSqlServerDataLayer, ISelfieDataLayer
    {
        public SqlServerSelfieDataLayer(SelfieDbContext context) : base(context)
        {
        }

        public IUnitOfWork UnitOfWork => this.Context;

        public Selfie Add(Selfie item)
        {
            Context.Entry<Wookie>(item.Wookie).State = EntityState.Detached;
            Context.Entry<Selfie>(item).State = EntityState.Added;
            return Context.Selfies.Add(item).Entity;
        }

        public ICollection<Selfie> Find(Expression<Func<Selfie, bool>> predicate)
        {
            return Context.Selfies.Where(predicate).Include(x=>x.Wookie).ToList();
        }

        public ICollection<Selfie> GetAll()
        {
            return Context.Selfies.Include(x=>x.Wookie).ToList();
        }

        public Selfie? GetById(int id)
        {
            return Context.Selfies.Include(x => x.Wookie).Where(x=>x.Id==id).FirstOrDefault();
        }

        public ICollection<Selfie> GetAllByWookie(int? id)
        {
            var result = (from s in Context.Selfies
                         join w in Context.Wookies on s.Wookie.Id equals w.Id
                         where w.Id == id
                         select s).Include(x=>x.Wookie);
            return result.ToList();
            //return Context.Wookies.Find(id)?.Selfies.ToList() ?? new List<Selfie>();
        }
    }
}
