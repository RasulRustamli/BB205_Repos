namespace BB205_Pronia.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting= _context.Settings.ToDictionary(x => x.Key, x => x.Value);
            return View(setting);
        }
    }
}
