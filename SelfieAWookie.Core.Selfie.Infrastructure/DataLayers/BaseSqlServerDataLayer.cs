using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructure.DataLayers
{
    public abstract class BaseSqlServerDataLayer
    {
        private readonly SelfieDbContext _context;

        public BaseSqlServerDataLayer(SelfieDbContext context)
        {
            _context = context;
        }

        public SelfieDbContext Context { 
            get {
                return _context;
            } 
        }
    }
}
