using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using WebGrease.Css.Extensions;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace EmployeeRegistration.DAL
{
    public class scriptDB
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Datetime { get; set; }
        public string script { get; set; }
        public int iversion { get; set; }
        public List<string> XmlName { get; set; }

    }
    public class updatedb
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["empcreationDB"].ToString());
        public scriptDB GetAllXml()
        {
            scriptDB scriptobj = new scriptDB();
            scriptobj.XmlName = new List<string>();
            scriptobj.XmlName.Add("Employeetable.xml");
            return scriptobj;
        }
        public void updatescript()
        {
            scriptDB scriptobj = GetAllXml();
            List<scriptDB> lstobj = new List<scriptDB>();
            scriptobj.XmlName.ForEach(p => lstobj.AddRange(scriptDBs(p)));
            Executescript(lstobj);
        }

        void Executescript(List<scriptDB> lstobj = null)
        {
            lstobj.ForEach(p =>
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["empcreationDB"].ToString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(p.script, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            });
        }

        public List<scriptDB> scriptDBs(string xmlname)
        {
            //XmlDocument doc=new XmlDocument();
            List<scriptDB> lstdb = new List<scriptDB>();
            updatedb scriptobj = new updatedb();
            //Stream streemobj = scriptobj.GetType().Assembly.GetManifestResourceStream("EmployeeRegistration.XML." + xmlname)
            using (Stream streemobj = typeof(updatedb).Assembly.GetManifestResourceStream("EmployeeRegistration.XML." + xmlname))
            {
                XElement main = XElement.Load(streemobj);
                IEnumerable<XElement> data;
                data = from c in main.Elements("DBobject").Where(p => p.Elements("Type").Any(a =>
                {
                    string stype = a.Value.ToString().ToLower();
                    return (stype.CompareTo("sp") != 0 && stype.CompareTo("function") != 0 && stype.CompareTo("view") != 0);
                }))
                       select c;
                data.ForEach(p =>
                {
                    var name = p.Element("Name").Value;
                    var type = p.Element("Type").Value;
                    var creationDate = p.Element("CreationDate").Value;
                    var upgradeScript = p.Element("UpgradeScript").Value;
                    var author = p.Element("author").Value;
                    lstdb.Add(new scriptDB() { Name = name, Type = type, Datetime = creationDate, script = upgradeScript, iversion = 0 });
                });
            }
            return lstdb;
        }
    }
}