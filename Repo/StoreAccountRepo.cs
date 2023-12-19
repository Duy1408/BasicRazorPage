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
    public class StoreAccountRepo : IStoreAccountRepo 
    {
        StoreAccountDAO dao = new StoreAccountDAO();

        public StoreAccount CheckLogin(string username, string password)
        {
          return  dao.CheckLogin(username, password);
        }
    }
}
