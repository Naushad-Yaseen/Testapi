using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class CarModel
    {
        public string CarName { get; set; }
        public IFormFile Image { get; set; }
    }
}
