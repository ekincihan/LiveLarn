using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiveLarn.Core.DataAccess;
using LiveLarn.Service.Lookup.DataAccess;
using LiveLarn.Service.Lookup.Models.Entity;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveLarn.Service.Lookup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ODataRoutePrefix("City")]
    public class CityController : ControllerBase
    {
        private IApplicationContext<LookupDbContext> _context;
        public CityController(IApplicationContext<LookupDbContext> context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<City>>> Get()
        {
            using (var context = _context.Context())
            {
                return await context.Set<City>().Include(f => f.Districts).ToListAsync();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(City city)
        {
            using (var context = _context.Context())
            {
                await context.Set<City>().AddAsync(city);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                    return new OkResult();
                else
                    return new BadRequestResult();
            }
        }
    }
}