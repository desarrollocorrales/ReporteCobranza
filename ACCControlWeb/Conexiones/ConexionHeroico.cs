using System;
using System.Collections.Generic;
using FIREBIRD;
using System.Web;

namespace ACCControlWeb
{
    public class ConexionHeroico:ConexionFireBird
    {

        public ConexionHeroico()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["DB_PATH_HEROICO"];
            string usr = System.Configuration.ConfigurationManager.AppSettings["DB_USER_HEROICO"];
            string pwd = System.Configuration.ConfigurationManager.AppSettings["DB_PASS_HEROICO"];

            fb = new FIREBIRD.Fb(path, usr, pwd);
            fb.Open();
        }

    }
}