using EFCore.Models.NorthwindModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreWebAppRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration Configuration;
        private readonly NorthwindContext northwindContext;
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, NorthwindContext northwindContext)
        {
            _logger = logger;
            Configuration = configuration;
            this.northwindContext = northwindContext;
        }

        public ContentResult OnGet()
        {
            NorthwindContext context = new NorthwindContext();
            Employee emp1 = northwindContext.Employees.First<Employee>();

            var myKeyValue = Configuration["MyKey"];
            var title = Configuration["Position:Title"];
            var name = Configuration["Position:Name"];
            var defaultLogLevel = Configuration["Logging:LogLevel:Default"];            

            return Content($"MyKey value: {myKeyValue} \n" +
                           $"Title: {title} \n" +
                           $"Name: {name} \n" +
                           $"Emp Name: {emp1.FirstName} \n" +
                           $"Default Log Level: {defaultLogLevel}");
        }
    }
}