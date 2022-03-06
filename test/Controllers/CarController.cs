using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using test.DBContext;
using test.Entities;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly DataContext _context;
        //  [Obsolete]
        private readonly IHostingEnvironment _hostingEnv;

        //[Obsolete]
        public CarController(DataContext context, IHostingEnvironment hostingEnv)
        {
            _context = context;
            _hostingEnv = hostingEnv;
        }

        [HttpPost]
        [ActionName("uploadImage")]
        // [Obsolete]
        public async Task<ActionResult> Post([FromForm] CarModel carVM)
        {
            if (carVM.Image != null)
            {
                var a = _hostingEnv.WebRootPath;
                var fileName = Path.GetFileName(carVM.Image.FileName);
               // var filePath = Path.Combine(_hostingEnv.WebRootPath, "images", fileName);
                var filePath = Path.Combine(a, "images", fileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await carVM.Image.CopyToAsync(fileSteam);
                }

                Car car = new Car();
                car.CarName = carVM.CarName;
                car.ImagePath = filePath;  //save the filePath to database ImagePath field.
                _context.Add(car);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ActionName("getCarList")]
        public List<Car> getCarList()
        {
            return _context.Car.ToList();

        }

    }
}
