using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniReady.DAL;
using UniReady.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniReady.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext db)
        {
            _context = db;
        }

        public ActionResult Index()
        {
            var query = from jp in _context.Postings select jp;
            List<Posting> SelectedPostings = query.ToList();
            return View(SelectedPostings);
        }
    }
}

