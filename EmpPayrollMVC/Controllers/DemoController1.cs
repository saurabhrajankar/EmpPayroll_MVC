using BusinessLayer.Interface;
using EmpPayrollMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpPayrollMVC.Controllers
{
    public class DemoController1 : Controller
    {
        IUserBL iuserBL;
        public DemoController1(IUserBL iuserBL)
        {
            this.iuserBL = iuserBL;
        }
        [HttpGet]
        public IActionResult Addemp()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(EmpModel empModel)
        {
            if (ModelState.IsValid)
            {
                iuserBL.AddEmployee(empModel);
                
            }
            return View(empModel);
        }
        [HttpGet]
        public IActionResult index()
        { 
            List<EmpModel> empList = new List<EmpModel>();
            empList=iuserBL.GetAllEmployees();
            return View(empList);
        }
    }
}
