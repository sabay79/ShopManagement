using Microsoft.AspNetCore.Mvc;
using SM.Business.DataServices.Interfaces;
using SM.Business.Models;

namespace SM.WebApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        // GET: ShopController
        public ActionResult Index(string? search)
        {
            List<ShopModel> shops = new List<ShopModel>();
            if (search == null)
            {
                shops = _shopService.GetAll();

            }
            else
            {
                shops = _shopService.GetAll().Where(x => x.Description.ToLower()
                .Contains(search.Trim().ToLower())).ToList();
            }
            return View(shops);
        }

        // GET: ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopModel model)
        {
            try
            {
                _shopService.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            var shops = _shopService.GetAll().Where(x => x.Id == id).FirstOrDefault();
            return View(shops);
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShopModel model)
        {
            try
            {
                var shops = _shopService.GetAll().Where(x => x.Id == model.Id).FirstOrDefault();
                if (shops != null)
                {
                    shops.Name = model.Name;
                    shops.Description = model.Description;
                    shops.Location = model.Location;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            _shopService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
