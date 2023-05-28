using CoreEF.Models.OracleHR;
using CoreEF.Models.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.OracleHRRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //private readonly IConfiguration Configuration;
        //private readonly OracleHrContext oraclehrContext;
        //public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, OracleHrContext oraclehrContext)
        //{
        //    _logger = logger;
        //    Configuration = configuration;
        //    this.oraclehrContext = oraclehrContext;
        //}


        //public ContentResult OnGet()
        //{
        //    Employee emp1 = oraclehrContext.Employees.First<Employee>();
        //    return Content($"Emp Name: {emp1.FirstName} -- {emp1.LastName}");
        //}

        private readonly ILogger<IndexModel> _logger;
        //private readonly IEmpRepository _empRepository;
        //private readonly IDeptRepository _deptRepository;
        private readonly IJobRepository _jobRepository;
        public IndexModel(ILogger<IndexModel> logger,/* IEmpRepository empRepository, IDeptRepository deptRepository,*/ IJobRepository jobRepository)
        {
            _logger = logger;
            //this._empRepository = empRepository;
            //this._deptRepository = deptRepository;
            this._jobRepository = jobRepository;
        }
        public ContentResult OnGet()
        {
            Job job = _jobRepository.Get("AC_MGR");

            return Content($"Job Title: {job.JobTitle}");
        }
    }
}