using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using AJI;
using AJI.Data;
using AJI.Models;
using AJI.Models.AccountViewModels;
using AJI.Services;
using Microsoft.EntityFrameworkCore;

namespace AJI.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _context.Posts
                    .Include(p => p.Author)
                    .OrderByDescending(p => p.ModifiedOn)
                    .ToListAsync();
    
            if (!result.Any())
            {
                return View();
            }
            
            return View(result);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
