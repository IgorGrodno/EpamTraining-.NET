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
    public class ClientController : Controller
    {
        private readonly IService<Client> _service;

        public ClientController(IService<Client> service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var clients = await _service.GetAllAsync();

            return View(clients);
        }

        [System.Web.Http.HttpPost]
        public async Task<ActionResult> Save(ClientViewModel clientViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(clientViewModel);
            }

            var client = await _service.GetAsync(clientViewModel.Id);
            if (client != null)
            {
                client.Name = clientViewModel.Name;

                await _service.UpdateAsync(client);
            }

            return RedirectToLocal(redirectUrl);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var client = await _service.GetAsync(id);

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
            return RedirectToAction("Index", "Client");
        }
    }
}
