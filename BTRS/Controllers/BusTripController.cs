using BTRS.Data;
using BTRS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTRS.Controllers
{
    public class BusTripController : Controller
    {
        private SystemDbContext _context;

        public BusTripController(SystemDbContext context)
        {
            _context = context;
        }

        // GET: BusTripController
        public ActionResult Index()
        {
            return View(_context.trips.ToList());
        }

        // GET: BusTripController/Details/5
        public ActionResult Details(int id)
        {
            BusTrip trip = _context.trips.Find(id);

            return View(trip);
        }

        // GET: BusTripController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusTripController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BusTrip trip)
        {
            try
            {

                int adminId = (int)HttpContext.Session.GetInt32("adminID");

                Administrator admin = _context.admin.Where(
                  a => a.AdminID == adminId
                  ).FirstOrDefault();

                trip.Admin = admin;

                _context.trips.Add(trip);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusTripController/Edit/5
        public ActionResult Edit(int id)
        {
            BusTrip trip = _context.trips.Find(id);

            return View(trip);
        }

        // POST: BusTripController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BusTrip trip)
        {
            try
            {

                _context.trips.Update(trip);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: BusTripController/Delete/5
        public ActionResult Delete(int id)
        {
            BusTrip trip = _context.trips.Find(id);
            _context.trips.Remove(trip);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        // POST: BusTripController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BusTrip trip)
        {
            try
            {
                _context.trips.Remove(trip);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }


    }

    

