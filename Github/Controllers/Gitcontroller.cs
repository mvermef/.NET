using Microsoft.AspNetCore.Mvc;
using Github.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



namespace Github.Controllers
{
    public class Gitcontroller : Controller
    {
       private readonly GithubContext _context;

        public Gitcontroller(GithubContext context)//the database context
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        //gitds/Update
        [HttpPost]
         public IActionResult Updateto([FromBody] GitJSON gitjson)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    _context.AddRange(gitjson.gitdList);
                   _context.SaveChanges();//adding list to table.
                }
                return View();
            }
            catch (Exception ex)
            {
                
                   return RedirectToPage("Error", ex);
                
            }
        }
    }
}
               
                
       
