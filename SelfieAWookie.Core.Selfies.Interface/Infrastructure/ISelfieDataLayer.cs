using SelfieAWookie.Core.Selfies.Domain;
using System.Linq.Expressions;


namespace SelfieAWookie.Core.Selfies.Interface.Infrastructure
{
    public interface ISelfieDataLayer
    {
        public ICollection<Selfie> GetAll();
        public Selfie? GetById(int id);
        public ICollection<Selfie> Find(Expression<Func<Selfie, bool>> predicate); 
    }
}
