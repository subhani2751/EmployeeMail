using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using EmployeeRegistration.Models;
using System.Configuration;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace EmployeeRegistration.DAL
{
    public class data_layer
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["empcreationDB"].ToString());
        public List<SelectListItem> getdata(string name = "")
        {
            var statemodellst = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(name))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(name, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SelectListItem obj = new SelectListItem();
                    obj.Value = Convert.ToString(reader[0]);
                    obj.Text = Convert.ToString(reader[1]);
                    statemodellst.Add(obj);
                }
                conn.Close();
            }
            return statemodellst;
        }
        public List<SelectListItem> getCitys(int Id = 0)
        {
            var statemodellst = new List<SelectListItem>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetCitys", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SelectListItem obj = new SelectListItem();
                obj.Value = Convert.ToString(reader[0]);
                obj.Text = Convert.ToString(reader[1]);
                statemodellst.Add(obj);
            }
            conn.Close();
            return statemodellst;
        }
        public List<Empmodel> EMP_Save(Empmodel model=null)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("emp_save", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sname", model.sName);
            cmd.Parameters.AddWithValue("@biPhone", model.iPhone);
            cmd.Parameters.AddWithValue("@sEmail", model.sEmail);
            cmd.Parameters.AddWithValue("@sdateofbirth", string.Format("{0:yyyy-MM-dd}", model.sdateofbirth));
            cmd.Parameters.AddWithValue("@CityId", model.sCity);
            cmd.Parameters.AddWithValue("@StateId", model.sState);
            cmd.Parameters.AddWithValue("@iQualification", model.sQualification);
            cmd.Parameters.AddWithValue("@sHobbies", model.sHobbies);
            int rval=cmd.ExecuteNonQuery();
            conn.Close();
            if(rval == 1)
            {
                return Emp_All();
            }
            return new List<Empmodel>();
        }
        public List<Empmodel> Emp_All()
        {
            var Returnlst = new List<Empmodel>();
            var Hobbieslst = getdata("GetallHobbies");
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetAll_Emp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var empmodel = new Empmodel();
                empmodel.iMasteriD = Convert.ToInt32(reader[0]);
                empmodel.sName = Convert.ToString(reader[1]);
                empmodel.iPhone = Convert.ToInt64(reader[2]);
                empmodel.sEmail = Convert.ToString(reader[3]);
                empmodel.sdateofbirth = Convert.ToDateTime(string.Format("{0:yyyy-MM-dd}", reader[4].ToString()));//DateTime.ParseExact(reader[4].ToString(), "dd-MM-yyyy HH:mm:ss", null).ToString("yyyy-MM-dd");
                empmodel.sCity = Convert.ToString(reader[5]);
                empmodel.sState = Convert.ToString(reader[6]);
                empmodel.sQualification = Convert.ToString(reader[7]);
                empmodel.sHobbies = Convert.ToString(reader[8]);
                if (!string.IsNullOrEmpty(empmodel.sHobbies)&& Hobbieslst.Count>0)
                {
                    var lst= empmodel.sHobbies.Split(',');
                    empmodel.sHobbies = "";
                    lst.ForEach(x => {
                        Hobbieslst.ForEach(p =>
                        {
                            if (p.Value == x)
                            {
                                empmodel.sHobbies += p.Text + ",";
                            }
                        });
                    });  
                }
                Returnlst.Add(empmodel);
            }
            conn.Close();
            return Returnlst;
        }
    }
}