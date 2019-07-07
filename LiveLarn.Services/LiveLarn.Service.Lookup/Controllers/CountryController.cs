using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveLarn.Core.DataAccess;
using LiveLarn.Service.Lookup.DataAccess;
using LiveLarn.Service.Lookup.Models.Entity;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveLarn.Service.Lookup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ODataRoutePrefix("Country")]
    public class CountryController : ControllerBase
    {
        private IApplicationContext<LookupDbContext> _context;
        public CountryController(IApplicationContext<LookupDbContext> context)
        {
            _context = context;
        }
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            using (var context = _context.Context())
            {
                return await context.Set<Country>().Include(t => t.Cities).ThenInclude(f => f.Districts).ToListAsync();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Country country)
        {
            using (var context = _context.Context())
            {
                country.CreateDate = country.CreateDate ?? DateTime.UtcNow;
                country.IsActive = true;
                await context.Set<Country>().AddAsync(country);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                    return new OkResult();
                else
                    return new BadRequestResult();
            }
        }
    }
}