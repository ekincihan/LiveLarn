using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveLarn.Core.DataAccess;
using LiveLarn.Service.Education.DataAccess;
using LiveLarn.Service.Education.Models.Entity;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveLarn.Service.Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ODataRoutePrefix("ClassLevel")]
    public class ClassLevelController : ControllerBase
    {
        private IApplicationContext<EducationDbContext> _context;
        public ClassLevelController(IApplicationContext<EducationDbContext> context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<ClassLevel>>> Get()
        {
            using (var context = _context.Context())
            {
                return await context.Set<ClassLevel>().ToListAsync();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClassLevel classLevel)
        {
            using (var context = _context.Context())
            {
                classLevel.CreateDate = classLevel.CreateDate ?? DateTime.UtcNow;
                classLevel.IsActive = true;
                await context.Set<ClassLevel>().AddAsync(classLevel);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                    return new OkResult();
                else
                    return new BadRequestResult();
            }
        }
    }
}