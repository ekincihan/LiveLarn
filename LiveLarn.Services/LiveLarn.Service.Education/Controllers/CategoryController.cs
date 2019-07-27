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
    [ODataRoutePrefix("Category")]    
    public class CategoryController : ControllerBase
    {
        private IApplicationContext<EducationDbContext> _context;
        public CategoryController(IApplicationContext<EducationDbContext> context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            using (var context = _context.Context())
            {
                return await context.Set<Category>().ToListAsync();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            using (var context = _context.Context())
            {
                category.CreateDate = category.CreateDate ?? DateTime.UtcNow;
                category.IsActive = true;
                await context.Set<Category>().AddAsync(category);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                    return new OkResult();
                else
                    return new BadRequestResult();
            }
        }
    }
}