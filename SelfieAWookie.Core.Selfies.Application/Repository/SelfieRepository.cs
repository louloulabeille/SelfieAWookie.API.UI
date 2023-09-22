using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructure.DataLayers;
using SelfieAWookie.Core.Selfies.Interface.Infrastructure;
using SelfieAWookie.Core.Selfies.Interface.Repository;
using System.Linq.Expressions;

namespace SelfieAWookie.Core.Selfies.Application.Repository
{
    public class SelfieRepository : ISelfieRepository
    {
        private readonly ISelfieDataLayer _dataLayer;

        public SelfieRepository(ISelfieDataLayer dataLayer  ) 
        {
            _dataLayer = dataLayer;
        }

        public ICollection<Selfie> Find(Expression<Func<Selfie, bool>> predicate)
        {
            return _dataLayer.Find(predicate);
        }

        public ICollection<Selfie> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Selfie? GetById(int id)
        {
            return _dataLayer.GetById(id);
        }
    }
}