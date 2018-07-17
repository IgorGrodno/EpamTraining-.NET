using ManagersWeb.Models;
using ManagersWeb.Repositories;
using ManagersWeb.Services;
using ManagersWeb.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ManagersWeb.Controllers
{
    public class ClientController : Controller
    {
        private readonly SaleService _saleService;
        private readonly GoodsService _goodsService;
        private readonly ManagerService _managerService;
        private readonly ClientService _clientService;

        public ClientController()
        {
            _saleService = new SaleService(new SaleRepository());
            _goodsService = new GoodsService(new GoodsRepository());
            _managerService = new ManagerService(new ManagerRepository());
            _clientService = new ClientService(new ClientRepository());
        }

        public async Task<ActionResult> Index()
        {
            var clients = await _clientService.GetAllAsync();

            return View(clients);
        }

        public async Task<ActionResult> GetSales(int id)
        {
            List<SaleToView> saleToViews = new List<SaleToView>();
            var sales = await _saleService.GetByClientAsync(id);
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

        [HttpPost]
        public async Task<ActionResult> Save(ClientViewModel clientViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(clientViewModel);
            }

            var client = _clientService.Get(clientViewModel.Id);
            if (client != null)
            {
                client.Name = clientViewModel.Name;

                await _clientService.UpdateAsync(client);
            }

            return RedirectToLocal(redirectUrl);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var client = _clientService.Get(id);

            var clientViewModel = new ClientViewModel
            {
                Title = "Edit Client",
                AddButtonTitle = "Save",
                RedirectUrl = Url.Action("Index", "Client"),
                Name = client.Name,
                Id = client.Id
            };

            return View(clientViewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _clientService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        [System.Web.Http.HttpPost]       
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Client");
        }
    }
}
