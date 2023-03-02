using EmpPayrollMVC.Models;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly IConfiguration iconfiguration;

        public UserRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }
        //Add Employee
        public EmpModel AddEmployee(EmpModel empModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(iconfiguration.GetConnectionString("EmpMVC")))
                {
                    SqlCommand cmd = new SqlCommand("Addemp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpName", empModel.EmpName);
                    cmd.Parameters.AddWithValue("@Img", empModel.Img);
                    cmd.Parameters.AddWithValue("@Gender", empModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", empModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", empModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", empModel.StartDate);
                    cmd.Parameters.AddWithValue("@Note", empModel.Note);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
                    {
                        return empModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
