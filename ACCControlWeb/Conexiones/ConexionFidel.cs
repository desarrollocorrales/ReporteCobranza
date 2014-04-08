using System;
using System.Collections.Generic;
using FIREBIRD;
using System.Web;

namespace ACCControlWeb
{
    public class ConexionFidel:ConexionFireBird
    {

        public ConexionFidel() 
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["DB_PATH_FIDEL"];
            string usr = System.Configuration.ConfigurationManager.AppSettings["DB_USER_FIDEL"];
            string pwd = System.Configuration.ConfigurationManager.AppSettings["DB_PASS_FIDEL"];

            fb = new FIREBIRD.Fb(path, usr, pwd);
            fb.Open();
        }

    }
}