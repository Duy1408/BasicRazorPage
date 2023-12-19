using BusinessObject;
using DAO;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class EyeglassRepo : IEyeglassRepo
    {

        EyeglassDAO dao = new EyeglassDAO();

        public void AddNewEyeglass(Eyeglass eyeglass)
        {
           dao.AddNewEyeglass(eyeglass);
        }

        public void DeleteEyeglass(Eyeglass eyeglass)
        {
            dao.DeleteEyeglass(eyeglass);
        }

        public List<Eyeglass> GetEyeglass()
        {
            return dao.GetAllEyeglass();
        }

        public Eyeglass GetEyeglassById(int eyeglassid)
        {
           return dao.GetEyeglassByID(eyeglassid);
        }

        public void UpdateEyeglass(Eyeglass eyeglass)
        {
            dao.UpdateEyeglass(eyeglass);
        }
    }
}
