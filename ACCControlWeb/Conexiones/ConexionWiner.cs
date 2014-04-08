using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIREBIRD;

namespace ACCControlWeb
{
    public class ConexionWiner:ConexionFireBird
    {

        public ConexionWiner()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["DB_PATH_WINER"];
            string usr = System.Configuration.ConfigurationManager.AppSettings["DB_USER_WINER"];
            string pwd = System.Configuration.ConfigurationManager.AppSettings["DB_PASS_WINER"];

            fb = new FIREBIRD.Fb(path, usr, pwd);
            fb.Open();
        }

    }
}