using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCControlWeb
{
    public class FG
    {
        public static ConexionFireBird getCurrentConexion(string conexion)
        {
            ConexionFireBird conn;

            switch (conexion)
            {
                case "Abastecedora": conn = new ConexionAbastecedora(); break;
                case "Heroico": conn = new ConexionHeroico(); break;
                case "Libertad": conn = new ConexionLibertad(); break;
                case "Fidel": conn = new ConexionFidel(); break;
                case "Winer": conn = new ConexionWiner(); break;
                case "Friolala": conn = new ConexionFriolala(); break;
                case "FrioGomez": conn = new ConexionFrioGomez(); break;
                default: conn = new ConexionAbastecedora(); break;
            }

            return conn;
        }
    }
}