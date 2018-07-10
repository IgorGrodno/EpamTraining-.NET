using ManagersWeb.Models;
using ManagersWeb.Services;
using ManagersWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace ManagersWeb.Controllers
{
    public class GoodsController : Controller
    {
        private readonly IService<Goods> _service;

        public GoodsController(IService<Goods> service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var goodses = await _service.GetAllAsync();

            return View(goodses);
        }

        [System.Web.Http.HttpPost]
        public async Task<ActionResult> Save(GoodsViewModel goodsViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(goodsViewModel);
            }

            var goods = await _service.GetAsync(goodsViewModel.Id);
            if (goods != null)
            {
                goods.Name = goodsViewModel.Name;

                await _service.UpdateAsync(goods);
            }

            return RedirectToLocal(redirectUrl);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var goods = await _service.GetAsync(id);

            var goodsViewModel = new GoodsViewModel
            {
                Title = "Edit Goods",
                AddButtonTitle = "Save",
                RedirectUrl = Url.Action("Index", "Goods"),
                Name = goods.Name,
                Id = goods.Id
            };

            return View(goodsViewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        [System.Web.Http.HttpPost]
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Goods");
        }
    }
}
