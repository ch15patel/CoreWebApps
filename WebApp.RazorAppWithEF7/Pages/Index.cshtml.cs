using CoreEF.Models.Northwind;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace WebApp.RazorAppWithEF7.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
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
            Employee emp1 = northwindContext.Employees.Include(x => x.Orders).First<Employee>();
            
            return Content($"Emp Name: {emp1.FirstName} -- {emp1.LastName}");
        }
    }
}