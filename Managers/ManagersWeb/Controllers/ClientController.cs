using ManagersWeb.Repositories;
using ManagersWeb.Services;
using ManagersWeb.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ManagersWeb.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientService _service;

        public ClientController()
        {
            _service = new ClientService(new ClientRepository());
        }

        public async Task<ActionResult> Index()
        {
            var clients = await _service.GetAllAsync();

            return View(clients);
        }

        [HttpPost]
        public async Task<ActionResult> Save(ClientViewModel clientViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(clientViewModel);
            }

            var client = _service.Get(clientViewModel.Id);
            if (client != null)
            {
                client.Name = clientViewModel.Name;

                await _service.UpdateAsync(client);
            }

            return RedirectToLocal(redirectUrl);
        }

        public ActionResult Edit(int id)
        {
            var client =  _service.Get(id);

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
