using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCControlWeb {

    public class ConexionFireBird {

        protected FIREBIRD.Fb fb;

        public FIREBIRD.Fb Conexion
        {
            get 
            { 
                return fb; 
            }
        }
    }
}