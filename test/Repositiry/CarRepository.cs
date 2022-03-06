using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.DBContext;

namespace test.Repositiry
{
    public class CarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

    }
}
