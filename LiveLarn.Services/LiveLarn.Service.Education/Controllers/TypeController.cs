using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveLarn.Core.DataAccess;
using LiveLarn.Service.Education.DataAccess;
using LiveLarn.Service.Education.DataAccess.Abstract;
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
        private IEducationDbContext _context;
        public TypeController(IEducationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Models.Entity.Type>>> Get()
        {
            return (await _context.Types.FindAsync<Models.Entity.Type>(filter: null)).Current.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Models.Entity.Type type)
        {
            try
            {
                await _context.Types.InsertOneAsync(type);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}