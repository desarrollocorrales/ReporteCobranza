using System;
using System.Collections.Generic;
using FIREBIRD;
using System.Web;

namespace ACCControlWeb
{
    public class ConexionFriolala:ConexionFireBird
    {

        public ConexionFriolala()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["DB_PATH_FRIOLALA"];
            string usr = System.Configuration.ConfigurationManager.AppSettings["DB_USER_FRIOLALA"];
            string pwd = System.Configuration.ConfigurationManager.AppSettings["DB_PASS_FRIOLALA"];

            fb = new FIREBIRD.Fb(path, usr, pwd);
            fb.Open();
        }

    }
}