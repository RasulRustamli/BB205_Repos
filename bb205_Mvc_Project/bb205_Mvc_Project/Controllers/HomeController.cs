using bb205_Mvc_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace bb205_Mvc_Project.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {

            List<Student> students = new List<Student>();
            
            students.Add(new Student()
            {
                Name="Ziver",
            });
            students.Add(new Student()
            {
                Name = "Fidan",
            });
            students.Add(new Student()
            {
                Name = "Xedice",
            });



            //ViewBag.Students = students;
            //ViewData["data"]=students;
            //TempData["data"] = students;

            ViewBag.data = "Viewbag hello";
            ViewData["title"] = "ViewData Hello";
            TempData["data"] = "";


            return RedirectToAction("About");
        }


        public IActionResult About()
        {
            return View();
        }
       
    }
}
