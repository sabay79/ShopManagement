using SM.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Business.DataServices.Interfaces
{
    public interface IProductService
    {
        public List<ProductModel> GetAll();
        public void Add(ProductModel model);
        public void Delete(int id);
    }
}
