using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Unit_of_work
{
    public  interface IUnitofWork:IDisposable
    {
        void save();
    }
}
