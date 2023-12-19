using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class StoreAccountDAO
    {
        private readonly Eyeglasses2023DBContext _context;
        public StoreAccountDAO()
        {
            _context = new Eyeglasses2023DBContext();
        }

        public StoreAccount CheckLogin(string email, string password)
        {
            try
            {
                var account = _context.StoreAccounts.FirstOrDefault(c =>
                c.EmailAddress.Equals(email.Trim()) && c.AccountPassword.Equals(password.Trim()));
                if (account != null)
                {
                    return account;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
