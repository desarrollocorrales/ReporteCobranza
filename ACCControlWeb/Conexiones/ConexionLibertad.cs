using System;
using System.Collections.Generic;
using FIREBIRD;
using System.Web;

namespace ACCControlWeb
{
    public class ConexionLibertad:ConexionFireBird
    {

        public ConexionLibertad()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["DB_PATH_LIBERTAD"];
            string usr = System.Configuration.ConfigurationManager.AppSettings["DB_USER_LIBERTAD"];
            string pwd = System.Configuration.ConfigurationManager.AppSettings["DB_PASS_LIBERTAD"];

            fb = new FIREBIRD.Fb(path, usr, pwd);
            fb.Open();
        }

    }
}