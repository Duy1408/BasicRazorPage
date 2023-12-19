using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface IEyeglassRepo
    {

        List<Eyeglass> GetEyeglass();
        public void AddNewEyeglass(Eyeglass eyeglass);
        public void UpdateEyeglass(Eyeglass eyeglass);
        public Eyeglass GetEyeglassById(int eyeglassid);


        public void DeleteEyeglass(Eyeglass eyeglass);
    }
}
