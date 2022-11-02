using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Framework
{
    /// <summary>
    /// Implements a member of type "IUnitOfWork"
    /// </summary>
    public interface IRepository
    {

         IUnitOfWork UnitOfWork { get; }

    }
}
