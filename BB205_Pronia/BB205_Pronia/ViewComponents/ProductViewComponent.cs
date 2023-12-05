using Microsoft.EntityFrameworkCore;

namespace BB205_Pronia.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int key=1)
        {
            
            List<Product> products;
            switch (key)
            {
                case 1:products = _context.Products.Where(p => p.IsDeleted == false).Include(p => p.ProductImages).OrderByDescending(p=>p.Price).Take(3).ToList();
                    break;
                case 2: products = _context.Products.Where(p => p.IsDeleted == false).Include(p => p.ProductImages).OrderBy(p => p.Price).Take(3).ToList();
                    break;
                case 3:products = _context.Products.Where(p => p.IsDeleted == false).Include(p => p.ProductImages).OrderByDescending(p=>p.Id).Take(3).ToList();
                    break;
                default: products = _context.Products.Where(p => p.IsDeleted == false).Include(p => p.ProductImages).Take(3).ToList();
                    break;
            }
           
            return View(products);
        }

    }
}
