using BB205_Pronia.Areas.Manage.ViewModels.Product;
using Microsoft.EntityFrameworkCore;

namespace BB205_Pronia.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        AppDbContext _context { get; set; }
        IWebHostEnvironment _env { get; set; }

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> product = await _context.Products.Where(p=>p.IsDeleted==false).Include(p => p.Category)
                .Include(p => p.ProductTags).ThenInclude(pt => pt.Tag).Include(p => p.ProductImages).ToListAsync();
            return View(product);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVm createProductVm)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }
            bool resultCategory = await _context.Categories.AnyAsync(c => c.Id == createProductVm.CategoryId);
            if (!resultCategory)
            {
                ModelState.AddModelError("CategoryId", "Bele bir Category Movcud deyil");
                return View();
            }
            Product product = new Product()
            {
                Name = createProductVm.Name,
                Price = createProductVm.Price,
                Description = createProductVm.Description,
                SKU = createProductVm.SKU,
                CategoryId = createProductVm.CategoryId,
                ProductImages = new List<ProductImages>()
            };
            if (createProductVm.TagIds != null)
            {
                foreach (int tagId in createProductVm.TagIds)
                {
                    bool resultTag = await _context.Tags.AnyAsync(c => c.Id == tagId);
                    if (!resultTag)
                    {
                        ModelState.AddModelError("TagIds", $"{tagId}-idli Tag Movcud deyil");
                        return View();
                    }

                    ProductTag productTag = new ProductTag()
                    {
                        Product = product,
                        TagId = tagId,
                    };

                    _context.ProductTags.Add(productTag);

                }

            }

            if (!createProductVm.MainPhoto.CheckType("image/"))
            {
                ModelState.AddModelError("MainPhoto", "Duzgun formatda sekil daxil edin!");
                return View();
            }
            if (!createProductVm.MainPhoto.CheckLength(3000))
            {
                ModelState.AddModelError("MainPhoto", "maxsimum 3mb sekil yukleye bilersiniz");
                return View();
            }
            if (!createProductVm.HoverPhoto.CheckType("image/"))
            {
                ModelState.AddModelError("HoverPhoto", "Duzgun formatda sekil daxil edin!");
                return View();
            }
            if (!createProductVm.HoverPhoto.CheckLength(3000))
            {
                ModelState.AddModelError("HoverPhoto", "maxsimum 3mb sekil yukleye bilersiniz");
                return View();
            }

            ProductImages mainImage = new ProductImages()
            {
                IsPrime = true,
                ImgUrl = createProductVm.MainPhoto.Upload(_env.WebRootPath, @"\Upload\Product\"),
                Product = product,
            };
            ProductImages hoverImage = new ProductImages()
            {
                IsPrime = false,
                ImgUrl = createProductVm.HoverPhoto.Upload(_env.WebRootPath, @"\Upload\Product\"),
                Product = product,
            };
            TempData["Error"] = "";
            product.ProductImages.Add(mainImage);
            product.ProductImages.Add(hoverImage);
            if (createProductVm.Photos != null)
            {
                foreach (var item in createProductVm.Photos)
                {
                    if (!item.CheckType("image/"))
                    {
                        TempData["Error"] += $"{item.FileName} type duzgun deyil  \t";
                        continue;
                    }
                    if (!item.CheckLength(3000))
                    {
                        TempData["Error"] += $"{item.FileName} 3mb-dan yuxaridir  \t";
                        continue;
                    }
                    ProductImages newPhoto = new ProductImages()
                    {
                        IsPrime = null,
                        ImgUrl = item.Upload(_env.WebRootPath, @"\Upload\Product\"),
                        Product = product,
                    };
                    product.ProductImages.Add(newPhoto);
                }
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            Product product = await _context.Products.Where(p => p.IsDeleted == false).Include(p => p.Category)
                .Include(p => p.ProductTags)
                .ThenInclude(p => p.Tag)
                .Include(p => p.ProductImages)
                .Where(p => p.Id == id).FirstOrDefaultAsync();
            if (product is null)
            {
                return View("Error");
            }
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            UpdateProductVm updateProductVm = new UpdateProductVm()
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                SKU = product.SKU,
                CategoryId = product.CategoryId,
                TagIds = new List<int>(),
                productImages = new List<ProductImagesVm>()
            };

            foreach (var item in product.ProductTags)
            {
                updateProductVm.TagIds.Add(item.TagId);
            }
            foreach (var item in product.ProductImages)
            {
                ProductImagesVm productImages = new ProductImagesVm()
                {
                    IsPrime = item.IsPrime,
                    ImgUrl = item.ImgUrl,
                    Id = item.Id
                };
                updateProductVm.productImages.Add(productImages);
            }

            return View(updateProductVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVm updateProductVm)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }
            Product existProduct = await _context.Products.Where(p => p.IsDeleted == false).Include(p=>p.ProductImages).Include(p=>p.ProductTags).Where(p => p.Id == updateProductVm.Id).FirstOrDefaultAsync();
            if (existProduct is null)
            {
                return View("Error");
            }
            bool resultCategory = await _context.Categories.AnyAsync(c => c.Id == updateProductVm.CategoryId);
            if (!resultCategory)
            {
                ModelState.AddModelError("CategoryId", "Bele bir Category Movcud deyil");
                return View();
            }
            existProduct.Name = updateProductVm.Name;
            existProduct.Description = updateProductVm.Description;
            existProduct.Price = updateProductVm.Price;
            existProduct.SKU = updateProductVm.SKU;
            existProduct.CategoryId = updateProductVm.CategoryId;

            if (updateProductVm.TagIds != null)
            {

                foreach (int tagId in updateProductVm.TagIds)
                {
                    bool resultTag = await _context.Tags.AnyAsync(c => c.Id == tagId);
                    if (!resultTag)
                    {
                        ModelState.AddModelError("TagIds", $"{tagId}-idli Tag Movcud deyil");
                        return View();
                    }
                }
                List<int> createTags;
                if (existProduct.ProductTags!= null)
                {
                    createTags = updateProductVm.TagIds.Where(ti => !existProduct.ProductTags.Exists(pt => pt.TagId == ti)).ToList();
                }
                else
                {
                    createTags = updateProductVm.TagIds.ToList();
                }


                foreach (int tagId in createTags)
                {
                    ProductTag productTag = new ProductTag()
                    {
                        TagId = tagId,
                        ProductId = existProduct.Id
                    };
                    //existProduct.ProductTags.Add(productTag);
                    await _context.ProductTags.AddAsync(productTag);

                }

                List<ProductTag> removeTags = existProduct.ProductTags.Where(pt => !updateProductVm.TagIds.Contains(pt.TagId)).ToList();

                _context.ProductTags.RemoveRange(removeTags);

            }
            else
            {
                var productTagList = _context.ProductTags.Where(pt => pt.ProductId == existProduct.Id).ToList();
                _context.ProductTags.RemoveRange(productTagList);
            }
            TempData["Error"] = "";
            if (updateProductVm.MainPhoto != null)
            {
                if (!updateProductVm.MainPhoto.CheckType("image/"))
                {
                    ModelState.AddModelError("MainPhoto", "Duzgun formatda sekil daxil edin!");
                    return View();
                }
                if (!updateProductVm.MainPhoto.CheckLength(3000))
                {
                    ModelState.AddModelError("MainPhoto", "maxsimum 3mb sekil yukleye bilersiniz");
                    return View();
                }
                ProductImages newMainImages = new ProductImages()
                {
                    IsPrime = true,
                    ProductId = existProduct.Id,
                    ImgUrl = updateProductVm.MainPhoto.Upload(_env.WebRootPath, @"\Upload\Product\")
                };
                var oldmainPhoto = existProduct.ProductImages?.FirstOrDefault(p => p.IsPrime == true);
                existProduct.ProductImages?.Remove(oldmainPhoto);
                existProduct.ProductImages.Add(newMainImages);

            }
            if (updateProductVm.HoverPhoto != null)
            {
                if (!updateProductVm.HoverPhoto.CheckType("image/"))
                {
                    ModelState.AddModelError("HoverPhoto", "Duzgun formatda sekil daxil edin!");
                    return View();
                }
                if (!updateProductVm.HoverPhoto.CheckLength(3000))
                {
                    ModelState.AddModelError("HoverPhoto", "maxsimum 3mb sekil yukleye bilersiniz");
                    return View();
                }
                ProductImages newHoverImages = new ProductImages()
                {
                    IsPrime = false,
                    ProductId = existProduct.Id,
                    ImgUrl = updateProductVm.HoverPhoto.Upload(_env.WebRootPath, @"\Upload\Product\")
                };
                var oldHoverPhoto = existProduct.ProductImages?.FirstOrDefault(p => p.IsPrime == false);
                existProduct.ProductImages?.Remove(oldHoverPhoto);
                existProduct.ProductImages.Add(newHoverImages);
            }
            if(updateProductVm.Photos!=null)
            {
                foreach (var item in updateProductVm.Photos)
                {
                    if (!item.CheckType("image/"))
                    {
                        TempData["Error"] += $"{item.FileName} type duzgun deyil  \t";
                        continue;
                    }
                    if (!item.CheckLength(3000))
                    {
                        TempData["Error"] += $"{item.FileName} 3mb-dan yuxaridir  \t";
                        continue;
                    }
                    ProductImages newPhoto = new ProductImages()
                    {
                        IsPrime = null,
                        ImgUrl = item.Upload(_env.WebRootPath, @"\Upload\Product\"),
                        Product = existProduct,
                    };
                    existProduct.ProductImages.Add(newPhoto);
                }
            }
            if(updateProductVm.ImageIds!=null)
            {
                var removeListImage = existProduct.ProductImages?.Where(p => !updateProductVm.ImageIds.Contains(p.Id) && p.IsPrime == null).ToList();
                foreach (var item in removeListImage)
                {
                    existProduct.ProductImages.Remove(item);
                    item.ImgUrl.DeleteFile(_env.WebRootPath, @"\Upload\Product\");
                }
            }
            else
            {
                existProduct.ProductImages.RemoveAll(p => p.IsPrime == null);
            }
           


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products.Where(p => p.IsDeleted == false).FirstOrDefault(p => p.Id == id);
            if (product is null)
            {
                return View("Error");
            }
            product.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }


        //public async  Task<IActionResult> Detail(int id)
        //{
        //    var product = await _context.Products.Include(p => p.Category)
        //        .Include(p => p.ProductTags).ThenInclude(pt => pt.Tag).FirstOrDefaultAsync(p => p.Id == id);
        //    return View(product);
        //}
    }
}
