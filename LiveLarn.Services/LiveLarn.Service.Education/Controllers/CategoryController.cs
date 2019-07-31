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
using MongoDB.Driver;

namespace LiveLarn.Service.Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ODataRoutePrefix("Category")]    
    public class CategoryController : ControllerBase
    {
        private readonly IEducationDbContext _context;
        private readonly IMongoCollection<Category> _collection;
        public CategoryController(IEducationDbContext context)
        {
            _context = context;
            _collection = _context.Categories;
        }

        [HttpGet]
        [EnableQuery()]
        public IQueryable<Category> Get()
        {
            return _collection.AsQueryable<Category>();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            try
            {
                await _context.Categories.InsertOneAsync(category);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}