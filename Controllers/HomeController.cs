using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers {
    public class HomeController : Controller {
        private MyContext _context { get; set; }

        public HomeController (MyContext context) {
            _context = context;
        }

        [HttpGet ("")]
        public IActionResult Index () {
            return View ();
        }

        [HttpPost ("login")]
        public IActionResult Login (LoginUser userLogin) {
            if (ModelState.IsValid) {
                var userInDb = _context.Users.FirstOrDefault (u => u.Email == userLogin.LoginEmail);
                if (userInDb == null) {
                    ModelState.AddModelError ("LoginEmail", "Invalid Email/Password");
                    return View ("Index");
                } else {
                    var hasher = new PasswordHasher<LoginUser> ();
                    var result = hasher.VerifyHashedPassword (userLogin, userInDb.Password, userLogin.LoginPassword);
                    if (result == 0) {
                        ModelState.AddModelError ("LoginEmail", "Invalid Email/Password");
                        return View ("Index");
                    } else {
                        //initialize session...?
                        HttpContext.Session.SetInt32 ("userid", userInDb.UserId);
                        return Redirect ("/Dashboard");
                    }
                }
            } else {
                return View ("Index");
            }
        }

        [HttpPost ("register")]
        public IActionResult Register (User user) {
            if (ModelState.IsValid) {
                // If a User exists with provided email
                if (_context.Users.Any (u => u.Email == user.Email)) {
                    ModelState.AddModelError ("Email", "Email already in use!");
                    return View ("Index");
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User> ();
                    user.Password = Hasher.HashPassword (user, user.Password);
                    _context.Users.Add (user);
                    _context.SaveChanges ();
                    HttpContext.Session.SetInt32 ("userid", user.UserId);
                    return Redirect ("/Dashboard");
                }
            }
            return View ("Index");
        }

        [HttpGet ("Dashboard")]
        public IActionResult Dashboard () {
            int? IdinSession = HttpContext.Session.GetInt32 ("userid");
            for (var i = 0; i < 100; i++) {
                Console.WriteLine (IdinSession);
            }
            if (IdinSession == null) {
                HttpContext.Session.Clear ();
                return Redirect ("/");
            } else {
                ViewBag.User = _context.Users.FirstOrDefault (u => u.UserId == IdinSession);
                List<Wedding> weddings = _context.Weddings.Include (w => w.Creator).Include (w => w.RSVPs).ThenInclude (w => w.Attending).ToList ();
                return View (weddings);
            }
        }

        [HttpGet ("cancel/{weddid}")]
        public IActionResult Divorce (int weddid) {
            Wedding tocancel = _context.Weddings.FirstOrDefault (w => w.WeddingId == weddid);
            _context.Weddings.Remove (tocancel);
            _context.SaveChanges ();
            return RedirectToAction ("Dashboard");
        }

        [HttpGet ("Add")]
        public IActionResult Add () {

            return View ();
        }

        [HttpPost ("Create/Wedding")]
        public IActionResult Create (Wedding newwed) {
            if (ModelState.IsValid) {
                int? IdinSession = HttpContext.Session.GetInt32 ("userid");
                newwed.UserId = (int) IdinSession;
                _context.Weddings.Add (newwed);
                _context.SaveChanges ();
                return Redirect ("/Dashboard");
            } else {
                return View ("Add");
            }
        }

        [HttpGet ("Join/{userid}/{weddid}")]
        public IActionResult Join (int userid, int weddid) {
            Invitation tojoin = new Invitation ();
            tojoin.UserId = userid;
            tojoin.WeddingId = weddid;
            _context.Invitations.Add (tojoin);
            _context.SaveChanges ();
            return RedirectToAction ("Dashboard");
        }

        [HttpGet ("Leave/{userid}/{weddid}")]
        public IActionResult Leave (int userid, int weddid) {
            Invitation toleave = _context.Invitations.FirstOrDefault (x => x.WeddingId == weddid && x.UserId == userid);
            _context.Invitations.Remove (toleave);
            _context.SaveChanges ();
            return RedirectToAction ("Dashboard");
        }

        [HttpGet ("Logout")]
        public IActionResult Logout () {
            HttpContext.Session.Clear ();
            return Redirect ("/");
        }
    }
}