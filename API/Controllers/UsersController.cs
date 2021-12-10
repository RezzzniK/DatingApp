using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //adding routin
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            
            return await _context.USers.ToListAsync();
        }

        //api/users/2
        [Authorize]
        [HttpGet("{id}")]
        
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var userByID=_context.USers.FindAsync(id);
            return await userByID;
        }
    }
}