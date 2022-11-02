using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Framawork
{
    /// <summary>
    /// UnitOfWork (method SaveChanges) 
    /// </summary>

    public interface IUnitOfWork
    {
        // > Déclare la méthode "SaveChanges" qui est utilisé dans "DbContext" <
        public int SaveChanges();
    }
}
