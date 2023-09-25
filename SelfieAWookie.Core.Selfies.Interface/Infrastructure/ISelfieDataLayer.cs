using SelfieAWookie.Core.Selfies.Domain;
using System.Linq.Expressions;


namespace SelfieAWookie.Core.Selfies.Interface.Infrastructure
{
    public interface ISelfieDataLayer : IDataLayer
    {
        public ICollection<Selfie> GetAll();
        public Selfie? GetById(int id);
        public ICollection<Selfie> Find(Expression<Func<Selfie, bool>> predicate);
        public Selfie Add(Selfie item);
        public ICollection<Selfie> GetByWookie(int? id);
    }
}
