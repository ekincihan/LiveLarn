using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveLarn.Core.DataAccess;
using LiveLarn.Service.Education.DataAccess;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveLarn.Service.Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ODataRoutePrefix("Type")]
    public class TypeController : ControllerBase
    {
        private IApplicationContext<EducationDbContext> _context;
        public TypeController(IApplicationContext<EducationDbContext> context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Models.Entity.Type>>> Get()
        {
            using (var context = _context.Context())
            {
                return await context.Set<Models.Entity.Type>().ToListAsync();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Models.Entity.Type type)
        {
            using (var context = _context.Context())
            {
                type.CreateDate = type.CreateDate ?? DateTime.UtcNow;
                type.IsActive = true;
                await context.Set<Models.Entity.Type>().AddAsync(type);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                    return new OkResult();
                else
                    return new BadRequestResult();
            }
        }
    }
}