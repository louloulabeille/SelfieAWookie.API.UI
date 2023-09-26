using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructure.DataLayers;
using SelfieAWookie.Core.Selfies.Interface.Infrastructure;
using SelfieAWookie.Core.Selfies.Interface.Repository;
using SelfieAWookie.Core.Selfies.Interface.UnitOfWork;
using System.Linq.Expressions;

namespace SelfieAWookie.Core.Selfies.Application.Repository
{
    public class SelfieRepository : ISelfieRepository
    {
        private readonly ISelfieDataLayer _dataLayer;
        private readonly IImageDataLayer _imageDataLayer;

        public SelfieRepository(ISelfieDataLayer dataLayer, IImageDataLayer imageDataLayer  ) 
        {
            _dataLayer = dataLayer;
            _imageDataLayer = imageDataLayer;
        }

        public Selfie Add(Selfie item)
        {
            return _dataLayer.Add(item);
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

        public ICollection<Selfie> GetAllByWookie(int? id)
        {
            return _dataLayer.GetAllByWookie(id);
        }

        public int SaveChanges()
        {
            return _dataLayer.UnitOfWork.SaveChanges();
        }

        public Image AddImage(string url)
        {
            return _imageDataLayer.Add(url);
        }
    }
}