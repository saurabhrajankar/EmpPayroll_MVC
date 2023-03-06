using EmpPayrollMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{

    public interface IUserRL
    {
        public EmpModel AddEmployee(EmpModel empModel);
        public List<EmpModel> GetAllEmployees();
        public EmpModel GetEmployeeData(int id);
        public EmpModel Updateemp(EmpModel empModel);
        public bool DeleteEmp(int id);
    }
}
