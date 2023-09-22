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
    public class SqlServerWookieDataLayer : BaseSqlServerDataLayer, IWookieDataLayer
    {
        public SqlServerWookieDataLayer(SelfieDbContext context) : base(context)
        {
        }

        public ICollection<Wookie> Find(Expression<Func<Wookie, bool>> predicate)
        {
            return Context.Wookies.Where(predicate).ToList();
        }

        public ICollection<Wookie> GetAll()
        {
            return Context.Wookies.ToList();
        }

        public Wookie? GetById(int id)
        {
            return Context.Wookies.Find(id);
        }
    }
}
