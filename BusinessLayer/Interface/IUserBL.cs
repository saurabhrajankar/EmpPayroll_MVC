using EmpPayrollMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public EmpModel AddEmployee(EmpModel empModel);
    }
}
