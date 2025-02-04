using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Dal: Data Access Layer (.NET) or Dao: Data Access Object (Java)
    public interface IProductDal:IEntityRepository<Product>
    {
    }

    //interface metodları default public dir.
}
