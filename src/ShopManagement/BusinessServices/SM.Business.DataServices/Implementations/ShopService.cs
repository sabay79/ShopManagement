using SM.Business.DataServices.Interfaces;
using SM.Business.Models;

namespace SM.Business.DataServices.Implementations
{
    public class ShopService : IShopService
    {
        private List<ShopModel> shops = new List<ShopModel>();
        public List<ShopModel> GetAll()
        {
            shops.Add(new ShopModel { Id = 1, Name = "Shop 1", Description = "Grocery Shop", Location = "PK" });
            shops.Add(new ShopModel { Id = 2, Name = "Shop 2", Description = "Cosmetics Shop", Location = "PK" });

            return shops;
        }
        public void Add(ShopModel model)
        {
            shops.Add(model);
        }
        public void Delete(int id)
        {
            var shopToDelete = shops.Where(x => x.Id == id).FirstOrDefault();
            if (shopToDelete != null)
            {
                shops.Remove(shopToDelete);
            }
        }
    }
}
