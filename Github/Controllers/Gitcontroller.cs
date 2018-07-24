using Microsoft.AspNetCore.Mvc;
using Github.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> Updateto(string Json)   //just string data...
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    var data = JsonConvert.DeserializeObject<List<gitd>>(Json); //Convert from JSON to object...

                    await _context.AddRangeAsync(data);
                    _context.SaveChanges();//adding list to table.

                    
                }
                return Ok(); //RESPONSE

            }
            catch (Exception ex)
            {
               
                return BadRequest(ex); //ERROR RESPONSE
                
            }
        }
    }
}
               
                
       
