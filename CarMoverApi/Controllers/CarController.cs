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
            var tmpPlate = plate.ToUpper().Trim().Replace(" ", "").Replace("-", "");
            return _context.Cars.Where(x => x.Plate == tmpPlate).Include(x => x.User);
        }

        // POST
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Register([FromBody]User value)
        {
            var users = _context.Users.Include(p => p.Cars);
            
            var user = users.SingleOrDefault(x => x.FaceBookUserId == value.FaceBookUserId);
            if (user == null)
            {
                _context.Users.Add(value);
                
            }
            else
            {
                user.Name = value.Name;
                user.MobileNumber = value.MobileNumber;
                user.ChannelId = value.ChannelId;
                user.ConversationId = value.ConversationId;
                user.RecipientId = value.RecipientId;
                user.ServiceUrl = value.ServiceUrl;
                foreach (var item in value.Cars)
                {
                    if(!user.Cars.Any(p => p.Plate.ToUpper().Trim().Contains(item.Plate)))
                    {
                        user.Cars.Add(item);
                    }
                }
                _context.Update(user);
            }
            _context.SaveChanges();
            return StatusCode(201, value);
        }
    }
}