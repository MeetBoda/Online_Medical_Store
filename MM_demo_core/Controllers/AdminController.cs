using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM_demo_core.Data;
using MM_demo_core.ViewModel;

namespace MM_demo_core.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, UserManager<IdentityUser> userManager)
        {
            db = context;
            webHostEnvironment = hostEnvironment;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult dashboard()
        {
            var users = _userManager.Users;
            return View(users);
        }
        public IActionResult Adddrug()
        {
            return View();
        }
        public IActionResult show()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public IActionResult showdrug()
        {
            return View();
        }

        public IActionResult FileUpload(imgviewmodel imv)
        {
            string stringFileName = UploadFile(imv);

            var drug = new drug
            {
                Ename = imv.Ename,
                Eprize = imv.Eprize,
                ImageUrl3 = stringFileName,
                Eavailability = "1",
                Edescription = "This is for humans",
                Edetails = "This is best medicine for health"

            };
            db.drugs.Add(drug);
            db.SaveChanges();
            return RedirectToAction("dashboard", "Admin");
        }
        public string UploadFile(imgviewmodel imv)
        {
            string fileName = null;
            if (imv.ImageUrl3 != null)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + imv.ImageUrl3.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imv.ImageUrl3.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        public IActionResult editdrug(int id)
        {
            var edit = db.drugs.Where(x => x.EId == id).FirstOrDefault();
            return View(edit);
        }
        [HttpPost]
        public IActionResult editdrug(drug edit)
        {
            var itemEdit = db.drugs.Where(x => x.EId == edit.EId).FirstOrDefault();
            itemEdit.Eprize = edit.Eprize;
            itemEdit.Ename = edit.Ename;

            db.Entry(itemEdit).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("showdrug");
        }

        public IActionResult Deletedrug(int id)
        {

            var del = db.drugs.Find(id);
            db.drugs.Remove(del);
            db.SaveChanges();
            return RedirectToAction("showdrug");
        }

        [HttpPost]
        public async Task<IActionResult> userdelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} not found";
                return View("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("show");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("show");
            }
        }
    }
}
