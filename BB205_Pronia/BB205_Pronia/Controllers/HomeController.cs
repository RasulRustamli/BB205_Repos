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
        HomeVm homeVm = new HomeVm()
        {
            Sliders=await _db.Sliders.ToListAsync(),
            Products = await _db.Products.Include(p => p.ProductImages).ToListAsync()
        };

        return View(homeVm);
    }
}
