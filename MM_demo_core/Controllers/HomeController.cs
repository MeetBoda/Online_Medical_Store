using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MM_demo_core.Data;
using MM_demo_core.Models;
using System.Diagnostics;
using System.Dynamic;

namespace MM_demo_core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

       
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            db = context;
        }
       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult medico()
        {
            return View();
        }
        public IActionResult drug()
        {
            return View();
        }
        public IActionResult search(string search)
        {
            // return View(db.drugs.Where(x => x.Ename.Contains(search)).ToList());
            var dg = db.drugs.Where(x => x.Ename.Contains(search)).ToList();
            dynamic y1 = new ExpandoObject();
            y1.check = dg;
            return View(y1);

        }

        public IActionResult details(string name)
        {
            var dg = db.drugs.Where(x => x.Ename.Contains(name)).ToList();
            dynamic y1 = new ExpandoObject();
            y1.check = dg;
            return View(y1);
        }

        [Authorize]
        public IActionResult cart()
        {
            string email = User.Identity?.Name;
            //string email = Session["Email"].ToString();

            var na = db.carts.Where(x => x.Cemail == email).ToList();
            return View(na);
            //return View();
        }

        public IActionResult addtocart(int id)         
        {
            string email = User.Identity?.Name;
            drug dg = db.drugs.Where(s => s.EId == id).FirstOrDefault();

            if (email != null)
            {
                
                cart c = new cart();
                c.Cemail = email;
                //c.Cid = id;
                c.name = dg.Ename;
                c.price = Convert.ToInt32(dg.Eprize);
                c.image = dg.ImageUrl3;
                //  c.qty = Convert.ToInt32(qty);
                // c.qty = 1;
                c.bil = c.price;

                db.carts.Add(c);
                db.SaveChanges();
            }
            else
            {
                TempData["msg1"] = "You Are Not Logged In The System";

            }


            return RedirectToAction("cart");
        }

        public ActionResult Delete(int id)
        {

            var del = db.carts.Find(id);
            db.carts.Remove(del);
            db.SaveChanges();
            return RedirectToAction("cart");
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