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
    [ODataRoutePrefix("District")]
    public class DistrictController : ControllerBase
    {
        private IApplicationContext<LookupDbContext> _context;
        public DistrictController(IApplicationContext<LookupDbContext> context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<District>>> Get()
        {
            using (var context = _context.Context())
            {
                return await context.Set<District>().ToListAsync();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(District district)
        {
            using (var context = _context.Context())
            {
                district.CreateDate = district.CreateDate ?? DateTime.UtcNow;
                district.IsActive = true;
                await context.Set<District>().AddAsync(district);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                    return new OkResult();
                else
                    return new BadRequestResult();
            }
        }
    }
}