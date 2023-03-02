using Microsoft.VisualBasic;

namespace EmpPayrollMVC.Models
{
    public class EmpModel
    {
        public int id { get; set; }
        public string EmpName { get; set; }
        public string Img { get; set; }   
        public string Gender { get; set; }
        public string Department { get; set; }   
        public string Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Note { get; set; }

    }
}
