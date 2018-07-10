﻿using ManagersWeb.Models;
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
        private readonly IService<Manager> _service;

        public ManagerController(IService<Manager> service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var managers = await _service.GetAllAsync();

            return View(managers);
        }

        [System.Web.Http.HttpPost]
        public async Task<ActionResult> Save(ManagerViewModel managerViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(managerViewModel);
            }

            var manager = await _service.GetAsync(managerViewModel.Id);
            if (manager != null)
            {
                manager.Name = managerViewModel.Name;

                await _service.UpdateAsync(manager);
            }

            return RedirectToLocal(redirectUrl);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var manager = await _service.GetAsync(id);

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
            return RedirectToAction("Index", "Manager");
        }
    }
}