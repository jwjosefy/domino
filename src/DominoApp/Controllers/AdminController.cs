using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominoApp.Services;


namespace DominoApp.Controllers
{
    public class AdminController : Controller
    {
        private BackOfficeRepository _backOfficeRepository;

        public AdminController()
        {
                this._backOfficeRepository = new BackOfficeRepository();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("dashboard");
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}