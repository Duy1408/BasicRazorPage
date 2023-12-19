using BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public class LensTypeRepo : ILensTypeRepo
    {
        LensTypeDAO dao = new LensTypeDAO();

        public List<LensType> GetLensType()
        {
            return dao.GetLensType();
        }
    }
}
