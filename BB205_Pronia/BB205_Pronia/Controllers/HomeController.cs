using BB205_Pronia.DAL;
using BB205_Pronia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BB205_Pronia.Controllers;

public class HomeController:Controller
{
    AppDbContext _db;

    public HomeController(AppDbContext db)
    {
        _db = db;
    }

    public  async Task<IActionResult> Index()
    {
        //Response.Cookies.Append("Name", "Miraga", new CookieOptions()
        //{
        //    MaxAge = TimeSpan.FromSeconds(5)
        //});

        //HttpContext.Session.SetString("Name", "Ilkin");



        HomeVm homeVm = new HomeVm()
        {
            Sliders=await _db.Sliders.ToListAsync(),
            Products = await _db.Products.Where(p => p.IsDeleted == false).Include(p => p.ProductImages).ToListAsync()
        };

        return View(homeVm);
    }
}
