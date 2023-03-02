using BusinessLayer.Interface;
using EmpPayrollMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpPayrollMVC.Controllers
{
    public class EmpController : Controller
    {
        private readonly IUserBL iuserBL;
        public EmpController(IUserBL iuserBL)
        {
            this.iuserBL = iuserBL; 
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(EmpModel empModel)
        {
            if (ModelState.IsValid)
            {
                iuserBL.AddEmployee(empModel);
                return RedirectToAction("AddEmployee");
            }
            else
            {
                return View(empModel);
            }
        }

    }
}
