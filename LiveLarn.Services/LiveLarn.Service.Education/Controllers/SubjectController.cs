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
    [ODataRoutePrefix("Subject")]
    public class SubjectController : ControllerBase
    {
        private readonly IEducationDbContext _context;
        public SubjectController(IEducationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Subject>>> Get()
        {
            return (await _context.Subjects.FindAsync<Subject>(filter: null)).Current.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Subject subject)
        {
            try
            {
                await _context.Subjects.InsertOneAsync(subject);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}