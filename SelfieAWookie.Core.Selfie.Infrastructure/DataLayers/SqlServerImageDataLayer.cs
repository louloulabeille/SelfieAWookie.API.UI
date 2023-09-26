using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using SelfieAWookie.Core.Selfies.Interface.Infrastructure;
using SelfieAWookie.Core.Selfies.Interface.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructure.DataLayers
{
    public class SqlServerImageDataLayer : BaseSqlServerDataLayer, IImageDataLayer
    {
        public SqlServerImageDataLayer(SelfieDbContext context) : base(context)
        {
        }

        public IUnitOfWork UnitOfWork => this.Context;

        public Image Add(string url)
        {
            Image image = new Image() { 
                Url = url,
            };

            return this.Context.Images.Add(image).Entity;
        }
    }
}
