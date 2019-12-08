using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppLog.Core.Abstract;
using LiveLarn.Service.Company.DataAccess.Contexts;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveLarn.Service.Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ODataRoutePrefix("Company")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        private readonly ILogger<CompanyController> _logger;
        public CompanyController(CompanyDbContext context, ILogger<CompanyController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Model.Entity.Company>>> Get()
        {

            await _logger.Current().InfoAsync("test");
            return await _context.Set<Model.Entity.Company>().Include(t=>t.Branches).ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Post(Model.Entity.Company company)
        {
            try
            {
                company.CreateDate = company.CreateDate ?? DateTime.UtcNow;
                company.IsActive = true;
                await _context.Set<Model.Entity.Company>().AddAsync(company);
                await _context.SaveChangesAsync();

                await _logger.Current().InfoAsync("OK", "Test");
                return new OkResult();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}