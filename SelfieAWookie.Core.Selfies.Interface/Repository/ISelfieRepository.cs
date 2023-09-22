using SelfieAWookie.Core.Selfies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Interface.Repository
{
    public interface ISelfieRepository
    {
        public ICollection<Selfie> GetAll();
        public Selfie? GetById(int id);
        public ICollection<Selfie> Find(Expression<Func<Selfie, bool>> predicate);
    }
}
