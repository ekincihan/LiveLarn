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
    [ODataRoutePrefix("Subject")]
    public class SubjectController : ControllerBase
    {
        private IApplicationContext<EducationDbContext> _context;
        public SubjectController(IApplicationContext<EducationDbContext> context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Subject>>> Get()
        {
            using (var context = _context.Context())
            {
                return await context.Set<Subject>().ToListAsync();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Subject subject)
        {
            using (var context = _context.Context())
            {
                subject.CreateDate = subject.CreateDate ?? DateTime.UtcNow;
                subject.IsActive = true;
                await context.Set<Subject>().AddAsync(subject);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                    return new OkResult();
                else
                    return new BadRequestResult();
            }
        }
    }
}