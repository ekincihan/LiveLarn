using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppLog.Core.Abstract;
using LiveLarn.Core.DataAccess;
using LiveLarn.Core.DataAccess.EntityFramework;
using LiveLarn.Service.Company.DataAccess.Contexts;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveLarn.Service.Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ODataRoutePrefix("Company")]
    public class CompanyController : ControllerBase
    {
        private IApplicationContext<CompanyDbContext> _context;
        private readonly ILogger _logger;
        public CompanyController(IApplicationContext<CompanyDbContext> context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Model.Entity.Company>>> Get()
        {
            using (var context = _context.Context())
            {
                await _logger.Current().InfoAsync("test");
                return await context.Set<Model.Entity.Company>().Include(t=>t.Branches).ToListAsync();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Model.Entity.Company company)
        {
            try
            {
                using (var context = _context.Context())
                {
                    company.CreateDate = company.CreateDate ?? DateTime.UtcNow;
                    company.IsActive = true;
                    await context.Set<Model.Entity.Company>().AddAsync(company);
                    await context.SaveChangesAsync();

                    await _logger.Current().InfoAsync("OK", "Test");
                    return new OkResult();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}