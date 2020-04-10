using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Interface
{
    interface ILogin
    {
        bool Login(String user, String password);
        void Forgotpassword(String email);
    }
}
