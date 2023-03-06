using BusinessLayer.Interface;
using EmpPayrollMVC.Models;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL iuserRL;

        public UserBL(IUserRL iuserRL)
        {
            this.iuserRL = iuserRL;
        }

        public EmpModel AddEmployee(EmpModel empModel)
        {
            try
            {
                return iuserRL.AddEmployee(empModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<EmpModel> GetAllEmployees()
        {
            try
            {
                return iuserRL.GetAllEmployees();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public EmpModel GetEmployeeData(int id)
        {
            try
            {
                return iuserRL.GetEmployeeData(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public EmpModel Updateemp(EmpModel empModel)
        {
            try
            {
                return iuserRL.Updateemp(empModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteEmp(int id)
        {
            try
            {
                return iuserRL.DeleteEmp(id);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
