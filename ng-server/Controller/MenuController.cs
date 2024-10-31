using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ng_server.Connected;
using ng_server.Data.Entity;
using ng_server.Model;

namespace ng_server.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController: ControllerBase
    {
        private readonly ApplicationContext _context;
        
        public MenuController(ApplicationContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MenuDTO>>> GetAll()
        {
            var menus = await _context.Set<Menu>()
                .Include(c => c.Category)
                .Select(m => new MenuDTO
                {
                    Id = m.Id,
                    CategoryId=m.Category.Id,
                    CategoryName = m.Category.Name,
                    EatName = m.EatName,
                    Description = m.Description,
                    Price = m.Price,
                    Image = m.Image
                }).ToListAsync();

            return Ok(menus);
        }


    }
}