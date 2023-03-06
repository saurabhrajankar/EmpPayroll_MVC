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
    public class UserRL :IUserRL
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
        //Demo All user
      
       
        public List<EmpModel> GetAllEmployees()
        {
            try
            {
                List<EmpModel> listemp = new List<EmpModel>();
                using (SqlConnection con = new SqlConnection(iconfiguration.GetConnectionString("EmpMVC")))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Getallemp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())                  //this read fn use for read the data till are true
                        {
                            EmpModel empModel = new EmpModel();
                            empModel.id = Convert.ToInt32(rd["id"]);     //[Index Property] or column name
                            empModel.EmpName = rd["EmpName"].ToString();
                            empModel.Img = rd["Img"].ToString();
                            empModel.Gender = rd["Gender"].ToString();
                            empModel.Department = rd["Department"].ToString();
                            empModel.Salary = (rd["Salary"]).ToString();
                            empModel.StartDate = Convert.ToDateTime(rd["StartDate"]);
                            empModel.Note = rd["Note"].ToString();
                            listemp.Add(empModel);
                        }
                    }
                    
                    con.Close();
                }
                return listemp;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public EmpModel GetEmployeeData(int id)
        {
            try
            {
                EmpModel empModel = new EmpModel();
                using (SqlConnection con = new SqlConnection(iconfiguration.GetConnectionString("EmpMVC")))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("empid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())                 
                        {
                           
                            empModel.id = Convert.ToInt32(rd["id"]);     
                            empModel.EmpName = rd["EmpName"].ToString();
                            empModel.Img = rd["Img"].ToString();
                            empModel.Gender = rd["Gender"].ToString();
                            empModel.Department = rd["Department"].ToString();
                            empModel.Salary = (rd["Salary"]).ToString();
                            empModel.StartDate = Convert.ToDateTime(rd["StartDate"]);
                            empModel.Note = rd["Note"].ToString();
                            
                        }
                    }
                    con.Close();
                }
                return empModel;
               
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public EmpModel Updateemp(EmpModel empModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(iconfiguration.GetConnectionString("EmpMVC")))
                {
                    SqlCommand cmd = new SqlCommand("Updtemp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",empModel.id);
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
        public bool DeleteEmp(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(iconfiguration.GetConnectionString("EmpMVC")))
                {
                    SqlCommand cmd = new SqlCommand("DeleteEmp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
