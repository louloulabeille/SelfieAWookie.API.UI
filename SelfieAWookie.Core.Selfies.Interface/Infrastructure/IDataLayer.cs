using SelfieAWookie.Core.Selfies.Interface.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Interface.Infrastructure
{
    public interface IDataLayer
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
