using SM.Business.Models;

namespace SM.Business.DataServices.Interfaces
{
    public interface IShopService
    {
        public List<ShopModel> GetAll();
        public void Add(ShopModel model);
        public void Delete(int id);
    }
}
