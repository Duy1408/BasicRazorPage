using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class LensTypeDAO
    {
        private readonly Eyeglasses2023DBContext _context;
        public LensTypeDAO()
        {
            _context = new Eyeglasses2023DBContext();
        }

        public List<LensType> GetLensType() => _context.LensTypes.ToList();
    }
}
