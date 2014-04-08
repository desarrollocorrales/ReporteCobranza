using System;
using System.Collections.Generic;
using System.Web;
using SQL;

namespace ACCControlWeb
{
    public class ConexionMySql
    {

        protected MySQL sql;

        public MySQL Conexion
        {
            get 
            { 
                return sql; 
            }
        }

    }
}