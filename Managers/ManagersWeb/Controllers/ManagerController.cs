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
    public class ManagerController : Controller
    {
        private readonly SaleService _saleService;
        private readonly GoodsService _goodsService;
        private readonly ManagerService _managerService;
        private readonly ClientService _clientService;

        public ManagerController()
        {
            _saleService = new SaleService(new SaleRepository());
            _goodsService = new GoodsService(new GoodsRepository());
            _managerService = new ManagerService(new ManagerRepository());
            _clientService = new ClientService(new ClientRepository());
        }

        public async Task<ActionResult> Index()
        {
            var managers = await _managerService.GetAllAsync();

            return View(managers);
        }

        public async Task<ActionResult> GetSales(int id)
        {
            List<SaleToView> saleToViews = new List<SaleToView>();
            var sales = await _saleService.GetByManagerAsync(id);
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
        public async Task<ActionResult> Save(ManagerViewModel managerViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(managerViewModel);
            }

            var manager = _managerService.Get(managerViewModel.Id);
            if (manager != null)
            {
                manager.Name = managerViewModel.Name;

                await _managerService.UpdateAsync(manager);
            }

            return RedirectToLocal(redirectUrl);
        }

        public ActionResult Edit(int id)
        {
            var manager = _managerService.Get(id);

            var managerViewModel = new ManagerViewModel
            {
                Title = "Edit Manager",
                AddButtonTitle = "Save",
                RedirectUrl = Url.Action("Index", "Manager"),
                Name = manager.Name,
                Id = manager.Id
            };

            return View(managerViewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _managerService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        [System.Web.Http.HttpPost]
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Manager");
        }


    }
}
