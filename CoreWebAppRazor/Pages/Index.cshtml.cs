using EFCore.Models.NorthwindModel;
using EFCore.Models.OracleHRModel;
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
        private readonly OracleHrContext oraclehrContext;
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, NorthwindContext northwindContext, OracleHrContext oraclehrContext)
        {
            _logger = logger;
            Configuration = configuration;
            this.northwindContext = northwindContext;
            this.oraclehrContext = oraclehrContext;
        }

        public ContentResult OnGet()
        {            
            EFCore.Models.NorthwindModel.Employee emp1 = northwindContext.Employees.First<EFCore.Models.NorthwindModel.Employee>();
            
            EFCore.Models.OracleHRModel.Employee emp2 = oraclehrContext.Employees.First<EFCore.Models.OracleHRModel.Employee>();

            var myKeyValue = Configuration["MyKey"];
            var title = Configuration["Position:Title"];
            var name = Configuration["Position:Name"];
            var defaultLogLevel = Configuration["Logging:LogLevel:Default"];            

            return Content($"MyKey value: {myKeyValue} \n" +
                           $"Title: {title} \n" +
                           $"Name: {name} \n" +
                           $"Emp Name: {emp1.FirstName} -- {emp2.FirstName} \n" +
                           $"Default Log Level: {defaultLogLevel}");
        }
    }
}