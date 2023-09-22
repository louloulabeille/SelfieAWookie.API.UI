using SelfieAWookie.Core.Selfies.Domain;
using System.Linq.Expressions;

namespace SelfieAWookie.Core.Selfies.Interface.Infrastructure
{
    public interface IWookieDataLayer : IDataLayer
    {
        public ICollection<Wookie> GetAll();
        public Wookie? GetById(int id);
        public ICollection<Wookie> Find(Expression<Func<Wookie, bool>> predicate);
    }
}
