using AdoptionCenter.DataAccess.EF.Context;
using AdoptionCenter.DataAccess.EF.Models;
using AdoptionCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdoptionCenter.Controllers
{
    public class PetsController : Controller
    {
        
        private readonly AdoptionWebsiteContext _context;

        
        public PetsController(AdoptionWebsiteContext context)
        {
            _context = context;
        }

        /*
        private readonly ILogger<PetsController> _logger;

        public PetsController(ILogger<PetsController> logger)
        {
            _logger = logger;
        }
        */

        public IActionResult Index()
        {
            PetsViewModel model = new PetsViewModel(_context);
            return View(model);

        }

        
        [HttpPost]
        public IActionResult Index(int petId, string petName, string petBreed, int petAge, string petDesc)
        {
            PetsViewModel model = new PetsViewModel(_context);

            Pet pet = new Pet(petId, petName, petBreed, petAge, petDesc);

            model.SavePet(pet);
            model.IsActionSuccess = true;
            model.ActionMessage = "Pet has been saved successfully";

            return View(model);
        }

        public IActionResult GiveUpForAdoption()
        {
            PetsViewModel model = new PetsViewModel(_context);
            return View(model);

        }

        public IActionResult Update(int id)
        {
            PetsViewModel model = new PetsViewModel(_context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            PetsViewModel model = new PetsViewModel(_context);

            if (id > 0)
            {
                model.RemovePet(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Thank you";
            return View("Index", model);
        }

    }
}
