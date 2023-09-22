using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Interface.Infrastructure;
using SelfieAWookie.Core.Selfies.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Application.Repository
{
    public class WookieRepository : IWookieRepository
    {
        private readonly IWookieDataLayer _dataLayer;

        public WookieRepository(IWookieDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ICollection<Wookie> Find(Expression<Func<Wookie, bool>> predicate)
        {
            return _dataLayer.Find(predicate);
        }

        public ICollection<Wookie> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Wookie? GetById(int id)
        {
            return _dataLayer.GetById(id);
        }
    }
}
