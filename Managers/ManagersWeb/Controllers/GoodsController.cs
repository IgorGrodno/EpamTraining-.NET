using ManagersWeb.Models;
using ManagersWeb.Repositories;
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
        private readonly SaleService _saleService;
        private readonly GoodsService _goodsService;
        private readonly ManagerService _managerService;
        private readonly ClientService _clientService;

        public GoodsController()
        {
            _saleService = new SaleService(new SaleRepository());
            _goodsService = new GoodsService(new GoodsRepository());
            _managerService = new ManagerService(new ManagerRepository());
            _clientService = new ClientService(new ClientRepository());
        }
            public async Task<ActionResult> Index()
        {
            var goodses = await _goodsService.GetAllAsync();

            return View(goodses);
        }

        public async Task<ActionResult> GetSales(int id)
        {
            List<SaleToView> saleToViews = new List<SaleToView>();
            var sales = await _saleService.GetByGoodsAsync(id);
            foreach (var item in sales)
            {
                saleToViews.Add(new SaleToView
                {
                    Id = item.Id,
                    ClientName = _clientService.Get(item.ClientId).Name,
                    ManagerName = _managerService.Get(item.ManagerId).Name,
                    GoodsName = _goodsService.GetAsync(item.GoodsId).Name,
                    Date = item.Date,
                    Summ = item.Summ
                });

            }
            return View(saleToViews);
        }

        [System.Web.Http.HttpPost]
        public async Task<ActionResult> Save(GoodsViewModel goodsViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(goodsViewModel);
            }

            var goods = _goodsService.GetAsync(goodsViewModel.Id);
            if (goods != null)
            {
                goods.Name = goodsViewModel.Name;

                await _goodsService.UpdateAsync(goods);
            }

            return RedirectToLocal(redirectUrl);
        }

        public ActionResult Edit(int id)
        {
            var goods = _goodsService.GetAsync(id);

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
            await _goodsService.DeleteAsync(id);

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
