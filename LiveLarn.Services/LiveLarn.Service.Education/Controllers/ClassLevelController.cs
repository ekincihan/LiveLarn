using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveLarn.Core.DataAccess;
using LiveLarn.Service.Education.DataAccess;
using LiveLarn.Service.Education.DataAccess.Abstract;
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
        private readonly IEducationDbContext _context;
        public ClassLevelController(IEducationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<ClassLevel>>> Get()
        {
            return (await _context.ClassLevels.FindAsync<ClassLevel>(filter: null)).Current.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClassLevel classLevel)
        {
            try
            {
                await _context.ClassLevels.InsertOneAsync(classLevel);

                return new OkResult();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}