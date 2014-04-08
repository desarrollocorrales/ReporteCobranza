using System;
using System.Collections.Generic;
using FIREBIRD;
using System.Web;

namespace ACCControlWeb
{
    public class ConexionFrioGomez:ConexionFireBird
    {

        public ConexionFrioGomez()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["DB_PATH_FRIOGOMEZ"];
            string usr = System.Configuration.ConfigurationManager.AppSettings["DB_USER_FRIOGOMEZ"];
            string pwd = System.Configuration.ConfigurationManager.AppSettings["DB_PASS_FRIOGOMEZ"];

            fb = new FIREBIRD.Fb(path, usr, pwd);
            fb.Open();
        }

    }
}