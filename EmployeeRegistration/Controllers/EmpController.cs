using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeRegistration.Models;
using EmployeeRegistration.DAL;
using System.Web.Optimization;

namespace EmployeeRegistration.Controllers
{
    public class EmpController : Controller
    {
        // GET: employee
        Empmodel model = new Empmodel();
        data_layer data_Layer = new data_layer();  
        public ActionResult employeescreen()
        {
            //List<SelectListItem> statlelst = data_Layer.getdata("GetallStates");
            //List<SelectListItem> Hobbieslst = data_Layer.getdata("GetallHobbies");
            //ViewData["statlelst"] = statlelst;
            //ViewData["Hobbieslst"] = Hobbieslst;
            return View();
        }
        [HttpPost]
        public JsonResult GetCities(int stateid = 0)
        {
            List<SelectListItem> GetCities = data_Layer.getCitys(stateid);
            return Json(GetCities, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EmpSave(Empmodel model =null)
        {
          // var empmodels = data_Layer.EMP_Save(model);
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}