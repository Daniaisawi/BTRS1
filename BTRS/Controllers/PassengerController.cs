using BTRS.Data;
using BTRS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTRS.Controllers
{
    public class PassengerController : Controller
    {
        private SystemDbContext _context;

        public PassengerController(SystemDbContext context)
        {
            _context = context;
        }


        // GET: PassengerController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUP(Passenger passenger)
        {

            bool empty = checkEmpty(passenger);
            bool duplicat = checkEmail(passenger.Email);

            if (empty)
            {
                if (duplicat)
                {
                    _context.passengers.Add(passenger);
                    _context.SaveChanges();

                    TempData["Msg"] = "the data was saved";
                    return View();
                }
                else
                {
                    TempData["Msg"] = "Please Change the username";
                    return View();
                }
            }
            else
            {
                TempData["Msg"] = "Please fill all input ";
                return View();
            }



        }


        public bool checkEmail(string email)
        {


            Passenger passenger = _context.passengers.Where(u => u.Email.Equals(email)).FirstOrDefault();
            if (passenger != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkEmpty(Passenger passenger)
        {
            if (String.IsNullOrEmpty(passenger.Username)) return false;
            else if (String.IsNullOrEmpty(passenger.Password)) return false;
            else if (String.IsNullOrEmpty(passenger.Name)) return false;
            else if (String.IsNullOrEmpty(passenger.Gender)) return false;
            else if (String.IsNullOrEmpty(passenger.Email)) return false;
            else if (String.IsNullOrEmpty(passenger.PhoneNumber)) return false;


            else return true;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult  Login(Login login)
        {
            if (ModelState.IsValid)
            {
                string username = login.UserName;
                string password = login.Password;

                Passenger p = _context.passengers.Where(
                     p => p.Username.Equals(username) &&
                     p.Password.Equals(password)
                     ).FirstOrDefault();

                Administrator admin = _context.admin.Where(
                    a => a.Username.Equals(username)
                    &&
                    a.Password.Equals(password)
                    ).FirstOrDefault();
                if (p != null)
                {
            

                    return RedirectToAction("TripList");
                }
                else if (admin != null)
                {

                    HttpContext.Session.SetInt32("adminID", admin.AdminID) ;

                    return RedirectToAction("Index", "BusTrip");
                }
                else
                {
                    TempData["Msg"] = "The user Not Found";
                }


            }
            else
            {

            }
            return View();
        }


        public IActionResult TripList()
        {
            return View(_context.trips.ToList());
        }

        public IActionResult AddTrip(int id)
        {
           

            return View();
        }
        
    }
}


           
 


