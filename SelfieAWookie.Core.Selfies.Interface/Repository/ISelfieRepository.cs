using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Interface.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Interface.Repository
{
    public interface ISelfieRepository : IUnitOfWork
    {
        public ICollection<Selfie> GetAll();
        public Selfie? GetById(int id);
        public ICollection<Selfie> Find(Expression<Func<Selfie, bool>> predicate);
        public Selfie Add (Selfie item);
        public ICollection<Selfie> GetByWookie(int? id);
    }
}
