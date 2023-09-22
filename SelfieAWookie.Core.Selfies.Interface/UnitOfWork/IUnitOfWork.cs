using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Interface.UnitOfWork
{
    public interface IUnitOfWork
    {
        public int SaveChanges();
    }
}
