using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Framework
{
    public interface IUnitOfWork
    {
        public int SaveChanges();

    }
}
