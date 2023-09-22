using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using SelfieAWookie.Core.Selfies.Interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructure.DataLayers
{
    public class SqlServerSelfieDataLayer : BaseSqlServerDataLayer, ISelfieDataLayer
    {
        public SqlServerSelfieDataLayer(SelfieDbContext context) : base(context)
        {
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
    }
}
