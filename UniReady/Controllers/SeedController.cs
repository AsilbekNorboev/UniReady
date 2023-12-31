﻿//TODO: Change this using statement to match your project (LastName_FirstName_HW3)
using UniReady.DAL;
using Microsoft.AspNetCore.Mvc;


//TODO: Update this namespace to match your project's name
namespace UniReady.Controllers
{
    public class SeedController : Controller
    {
        private AppDbContext _db;

        public SeedController(AppDbContext context)
        {
            _db = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeedPostings()
        {
            try
            {
                Seeding.SeedPostings.SeedAllPostings(_db);
            }
            catch (Exception ex)
            {
                //create a new list to hold all the errors
                List<String> errors = new List<String>();

                //add a generic message
                errors.Add("There was an error adding categories to the database!");

                //add the message from the exception
                errors.Add(ex.Message);

                //add messages from inner exceptions (if there are any)
                if (ex.InnerException != null)
                {
                    errors.Add(ex.InnerException.Message);
                    if (ex.InnerException.InnerException != null)
                    {
                        errors.Add(ex.InnerException.InnerException.Message);
                        if (ex.InnerException.InnerException.InnerException != null)
                        {
                            errors.Add(ex.InnerException.InnerException.InnerException.Message);
                        }
                    }
                }

                //return the error message with the list of errors
                return View("Error", errors);
            }

            //everything is okay - return the confirmation page
            return View("Confirm");
        }
    }
}