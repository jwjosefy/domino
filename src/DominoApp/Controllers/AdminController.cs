using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominoApp.DomainModel.Common;
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
            return RedirectToAction("Dashboard");
        }

        public ActionResult Dashboard()
        {
            var settings = _backOfficeRepository.GetDominoSettings();

            return View(settings);
        }

        /// <summary>
        /// Salva as alterações de config no BD
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(DominoSettings settings)
        {
            _backOfficeRepository.SaveDominoSettings(settings);

            return RedirectToAction("Dashboard");
        }
    }
}