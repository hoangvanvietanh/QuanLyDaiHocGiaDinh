using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Interface
{
    interface IEmployee
    {
        void CreateEmployee();
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
