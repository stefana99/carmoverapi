using System.Collections.Generic;
using System.Linq;
using CarMoverApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMoverApi.Controllers
{
    public class CarController : Controller
    {
        private readonly CarMoverContext _context;

        public CarController(CarMoverContext context)
        {
            _context = context;
        }
        
        //GET
        [Route("api/[controller]")]
        [HttpGet]
        public IEnumerable<Car> Get(string plate)
        {
            return _context.Cars.Where(x => x.Plate == plate).Include(x => x.User);
        }

        // POST
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Register([FromBody]User value)
        {
            var user = _context.Users.SingleOrDefault(x => x.FaceBookUserId == value.FaceBookUserId);
            if (user == null)
            {
                _context.Users.Add(value);
                
            }
            else
            {
                user.Cars = value.Cars;
                
                _context.Update(user);
            }
            _context.SaveChanges();
            return StatusCode(201, value);
        }
    }
}