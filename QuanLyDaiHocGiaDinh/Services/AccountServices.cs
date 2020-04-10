using QuanLyDaiHocGiaDinh.Interface;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Services
{
    class AccountServices : IAccount
    {
        public void CreateAccount(Account account)
        {
            
        }

        public void DeleteAccount(Account account)
        {
            
        }

        public List<Account> GetAllAccounts()
        {
            using (LinQDataContext db = new LinQDataContext())
            {
                var account = from x in db.Accounts select x;
                return account.ToList();
            }
        }

        public void UpdateAccount(Account account)
        {
            
        }
    }
}
