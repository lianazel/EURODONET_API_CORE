using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Framawork
{
    public interface IRepository
    {
        public IUnitOfWork UnitOfWork { get; }

    }
}
