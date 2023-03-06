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
        public IActionResult Index()
        {
            List<EmpModel> objlist = new List<EmpModel>();
            objlist = iuserBL.GetAllEmployees().ToList();
            return View(objlist);
        }

        [HttpGet]
        public IActionResult Getempdata(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmpModel employee = iuserBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //Update EmpLoyee
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmpModel employee = iuserBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(int id, [Bind] EmpModel employee)
        {
            if (id != employee.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                iuserBL.Updateemp(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        //Add Employee
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
        //Delete Employess
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmpModel empModel = iuserBL.GetEmployeeData(id);

            if (empModel == null)
            {
                return NotFound();
            }
            return View(empModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            iuserBL.DeleteEmp(id);
            return RedirectToAction("Index");
        }

    }
}
