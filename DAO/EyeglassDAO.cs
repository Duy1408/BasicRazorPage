using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EyeglassDAO
    {
        private readonly Eyeglasses2023DBContext _context;
        public EyeglassDAO()
        {
            _context = new Eyeglasses2023DBContext();
        }
        public List<Eyeglass> GetAllEyeglass()
        {
            try
            {
                return _context.Eyeglasses.Include(c => c.LensType).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNewEyeglass(Eyeglass eyeglass)
        {
            try
            {
                _context.Add(eyeglass);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Eyeglass GetEyeglassByID(int id)
        {
            return _context.Eyeglasses.SingleOrDefault(a => a.EyeglassesId == id);
        }

        public void UpdateEyeglass(Eyeglass eyeglass)
        {
            try
            {

                _context.Attach(eyeglass).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteEyeglass(Eyeglass eyeglass)
        {
            var a = _context.Eyeglasses.FirstOrDefault(a => a.EyeglassesId == eyeglass.EyeglassesId);

            _context.Eyeglasses.Remove(a);
            _context.SaveChanges();
        }


       

    }
}

