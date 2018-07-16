using ManagersWeb.Models;
using ManagersWeb.Repositories;
using ManagersWeb.Services;
using ManagersWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ManagersWeb.Controllers
{

    public class SaleController : Controller
        {
            private readonly SaleService _saleService;
            private readonly GoodsService _goodsService;
            private readonly ManagerService _managerService;
            private readonly ClientService _clientService;
            
        public SaleController()
            {
            _saleService = new SaleService(new SaleRepository());
            _goodsService = new GoodsService(new GoodsRepository());
            _managerService = new ManagerService(new ManagerRepository());
            _clientService = new ClientService(new ClientRepository());
            }

            public async Task<ActionResult> Index()
            {
            List<SaleToView> saleToViews = new List<SaleToView>();
            
            var sales = await _saleService.GetAllAsync();
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

          
        public async Task<ActionResult> GetByManagerAsync(int id)
        {
            var sale = await _saleService.GetByManagerAsync(id);

            return View(sale);
        }

        public async Task<ActionResult> GetByGoodsAsync(int id)
        {
            var sale = await _saleService.GetByGoodsAsync(id);

            return View(sale);
        }

        public async Task<ActionResult> GetByClientAsync(int id)
        {
            var sale = await _saleService.GetByClientAsync(id);

            return View(sale);
        }

        public async Task<ActionResult> GetByDateAsync(DateTime startDate, DateTime endDate)
        {
            var sale = await _saleService.GetByDateAsync(startDate,endDate);

            return View(sale);
        }

        public ActionResult GetByDate()
        {
            var saleViewModel = new SaleViewModel
            {
                Title = "Get sales by date",
                AddButtonTitle = "Get",
                RedirectUrl = Url.Action("GetByDate", "Sale"),
               
            };

            return View(saleViewModel);
        }

        public ActionResult GetByManagerAsync()
        {
            return View();
        }

        public ActionResult GetByGoodsAsync()
        {
          
            return View();
        }

        public ActionResult GetByClientAsync()
        {
            
            return View();
        }

        public ActionResult GetByDateAsync()
        {
           
            return View();
        }

        public async Task<ActionResult> Delete(int id)
            {
                await _saleService.DeleteAsync(id);

                return RedirectToAction("Index");
            }

            [HttpPost]
            private ActionResult RedirectToLocal(string returnUrl)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Sale");
            }

        
    }

}
    

