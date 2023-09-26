using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Interface.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Interface.Infrastructure
{
    public interface IImageDataLayer : IDataLayer
    {
        public Image Add(string url);
    }
}
