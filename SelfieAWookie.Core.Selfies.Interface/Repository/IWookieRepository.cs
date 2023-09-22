using SelfieAWookie.Core.Selfies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Interface.Repository
{
    public interface IWookieRepository
    {
        public ICollection<Wookie> GetAll();
        public Wookie? GetById(int id);
        public ICollection<Wookie> Find(Expression<Func<Wookie, bool>> predicate);
    }
}
