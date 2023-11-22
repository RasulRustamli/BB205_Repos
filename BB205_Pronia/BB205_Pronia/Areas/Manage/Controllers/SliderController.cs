




using System.IO;

namespace BB205_Pronia.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController:Controller
    {
        AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SliderController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            List<Slider> sliderList = _context.Sliders.ToList();
            return View(sliderList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if(!slider.ImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError("ImageFile", "Yalnizca Sekil yukluye bilersiz");
                return View();
            }
            if (slider.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "Maxsimum 2mb yukluye bilersiz!!");
                return View();
            }

            //string filname = slider.ImageFile.FileName;
            //if(filname.Length >64 )
            //{
            //    filname= filname.Substring(filname.Length-64);
            //}
            //filname=Guid.NewGuid().ToString()+filname;

            ////string path = @"C:\Users\rasul\OneDrive\Masaüstü\BB205_Pronia\BB205_Pronia\wwwroot\Upload\SliderImage\" +filname;
            ////string path = _environment.WebRootPath + @"\Upload\SliderImage\" + filname;
            //using (FileStream stream = new FileStream(path,FileMode.Create))
            //{
            //    slider.ImageFile.CopyTo(stream);
            //}



            slider.ImgUrl = slider.ImageFile.Upload(_environment.WebRootPath, @"\Upload\SliderImage\");



                if (!ModelState.IsValid)
                {
                    return View();
                }
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();  


            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
            
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            FileManager.DeleteFile(slider.ImgUrl, _environment.WebRootPath, @"\Upload\SliderImage\");
            return RedirectToAction("Index");
        }
    }
}
