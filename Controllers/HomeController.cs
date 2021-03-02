using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExamOne.Models;
using ExamOne.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ExamOne.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        public User UserInDb()
        {
            return dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email","Email is already in use");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser log)
        {
            if(ModelState.IsValid)
            {
                User user = dbContext.Users.FirstOrDefault(u => u.Email == log.LoginEmail);
                if(user != null)
                {
                    var hash = new PasswordHasher<LoginUser>();
                    var result = hash.VerifyHashedPassword(log, user.Password, log.LoginPassword);
                    if(result == 0)
                    {
                        ModelState.AddModelError("LoginEmail", "Invalid login attempt");
                        return View("Index");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("UserId", user.UserId);
                        return RedirectToAction("Dashboard");
                    }
                }
                else
                {
                    ModelState.AddModelError("LoginEmail", "Invalid login attempt");
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }
            ViewBag.User = userInDb;
            List<Gathering> AllGatherings = dbContext.Gatherings.Include(u => u.Creator).Include(u => u.Participants).ThenInclude(p => p.Participant).Where(g => g.Start > DateTime.Now).OrderBy(g => g.Start).ToList();
            return View(AllGatherings);
        }

        [HttpGet("new")]
        public IActionResult NewActivity()
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }
            ViewBag.User = userInDb;
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Gathering created)
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }
            if(ModelState.IsValid)
            {
                dbContext.Gatherings.Add(created);
                dbContext.SaveChanges();
                return Redirect($"/activity/{created.GatheringId}");
            }
            else
            {
                ViewBag.User = userInDb;
                return View("NewActivity");
            }
        }

        [HttpGet("activity/{gatheringId}")]
        public IActionResult ShowActivity(int gatheringId)
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }
            Gathering activity = dbContext.Gatherings.Include(g => g.Creator).Include(g => g.Participants).ThenInclude(p => p.Participant).FirstOrDefault(g => g.GatheringId == gatheringId);
            ViewBag.User = userInDb;
            return View(activity);
        }

        [HttpGet("{status}/{gatheringId}/{userId}")]
        public IActionResult Status(string status, int gatheringId, int userId)
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }
            if(status == "join")
            {
                Participation going = new Participation();
                going.UserId = userId;
                going.GatheringId = gatheringId;
                dbContext.Participations.Add(going);
                dbContext.SaveChanges();
            }
            else if(status == "leave")
            {
                Participation leave = dbContext.Participations.FirstOrDefault(p => p.GatheringId == gatheringId && p.UserId == userId);
                dbContext.Participations.Remove(leave);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet("destroy/{gatheringId}")]
        public IActionResult DestroyActivity(int gatheringId)
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }
            Gathering cancel = dbContext.Gatherings.FirstOrDefault(g => g.GatheringId == gatheringId);
            dbContext.Gatherings.Remove(cancel);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
