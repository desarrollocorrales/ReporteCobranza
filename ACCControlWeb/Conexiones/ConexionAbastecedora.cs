using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCControlWeb
{
    public class ConexionAbastecedora:ConexionFireBird
    {
        public ConexionAbastecedora() 
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["DB_PATH_ACC"];
            string usr = System.Configuration.ConfigurationManager.AppSettings["DB_USER_ACC"];
            string pwd = System.Configuration.ConfigurationManager.AppSettings["DB_PASS_ACC"];

            fb = new FIREBIRD.Fb(path, usr, pwd);
            fb.Open();
        }
    }
}