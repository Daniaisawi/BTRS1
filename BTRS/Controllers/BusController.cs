using BTRS.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTRS.Controllers
{
    public class BusController : Controller
    {
        private SystemDbContext _context;

        public BusController(SystemDbContext context)
        {
            _context = context;
        }

        // GET: BusController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BusController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
