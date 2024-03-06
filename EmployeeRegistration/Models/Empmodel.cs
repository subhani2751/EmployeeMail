using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeRegistration.Models
{
    public class Empmodel
    {
        public int iMasteriD { get; set; }
        public string sName { get; set; }
        public long iPhone { get; set; }
        public string sEmail { get; set; }
        //public string sDesignation { get; set; }
        //public string sDeprtment { get; set; }
        public DateTime sdateofbirth { get; set; }
        public string sCity { get; set; }
        public string sState { get; set; }
        public string sHobbies { get; set; }
        public string sQualification { get; set; }
        //public int SelectedItemId { get; set; }
        //public IEnumerable<SelectListItem> StateList
        //{
        //    get 
        //    {
        //        List<SelectListItem> ItemList = new List<SelectListItem>
        //        {
        //            new SelectListItem { Text = "Andhra Pradesh", Value = "1" },
        //            new SelectListItem { Text = "Telangana", Value = "2" },
        //            new SelectListItem { Text = "Tamil Nadu", Value = "3" },
        //            new SelectListItem { Text = "Maharashtra", Value = "4" },
        //            new SelectListItem { Text = "Bihar", Value = "5" },
        //            new SelectListItem { Text = "West Bengal", Value = "6" }
        //        };
        //      return ItemList;
        //    } 
        //}
    }
    public class statemodel
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}