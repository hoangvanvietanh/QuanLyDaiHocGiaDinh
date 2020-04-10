using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Interface
{
    interface IAccount
    {
        void CreateAccount(Account account);
        void DeleteAccount(Account account);
        void UpdateAccount(Account account);
        List<Account> GetAllAccounts();
    }
}
