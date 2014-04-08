using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MicroSipBusinessLayer;

namespace ACCControlWeb
{
    public partial class Cobranza : System.Web.UI.Page
    {
        ConexionFireBird conn;
        Cuentas_Cobrar cc;
        static DataTable tCobranza;

        protected void Page_Load(object sender, EventArgs e)
        {

            ControlAcc master = (ControlAcc)this.Master;

            
            if (master.Conexion=="") return;

            conn=FG.getCurrentConexion(master.Conexion);

            cc = new Cuentas_Cobrar(conn.Conexion);

            if(calFechaPronostico.Text!="")
                calFechaPronostico_DateChanged(calFechaPronostico, new EventArgs());
        }

        protected void calFechaPronostico_DateChanged(object sender, EventArgs e)
        {
            int year = calFechaPronostico.Date.Year
                , month = calFechaPronostico.Date.Month,
                day = calFechaPronostico.Date.Day;

            DateTime deFecha = calFechaPronostico.Date;
            DateTime aFecha = deFecha.AddDays(6);

            /*switch (day)
            {
                case 1: case 2: case 3: case 4:
                case 5: case 6: case 7: case 8:                
                        deFecha = new DateTime(year, month, 1);
                        aFecha = new DateTime(year, month, 8);
                        break;
                case  9: case 10: case 11: case 12:
                case 13: case 14: case 15: case 16:
                        deFecha = new DateTime(year, month, 9);
                        aFecha = new DateTime(year, month, 16);
                        break;
                case 17: case 18: case 19: case 20:
                case 21: case 22: case 23: case 24:
                        deFecha = new DateTime(year, month, 17);
                        aFecha = new DateTime(year, month, 24);
                        break;
                case 25: case 26: case 27: case 28:
                case 29: case 30: case 31:
                        deFecha = new DateTime(year, month, 25);
                        aFecha = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                        break;
            }
            /********
            if (day > 15)
            {
                deFecha = new DateTime(year, month, 16);
                aFecha = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            }
            else
            {
                deFecha = new DateTime(year, month, 1);
                aFecha = new DateTime(year, month, 15);
            }
            **********/

//            FirebirdSql.Data.FirebirdClient.FbCommand comm = new FirebirdSql.Data.FirebirdClient.FbCommand();
//            FirebirdSql.Data.FirebirdClient.FbDataAdapter adap = new FirebirdSql.Data.FirebirdClient.FbDataAdapter();
//            FirebirdSql.Data.FirebirdClient.FbConnection conn = new FirebirdSql.Data.FirebirdClient.FbConnection();
//            FirebirdSql.Data.FirebirdClient.FbConnectionStringBuilder conns = new FirebirdSql.Data.FirebirdClient.FbConnectionStringBuilder();
//            FirebirdSql.Data.FirebirdClient.FbDataReader reader;

//            conns.Database = "hcocorrales.dyndns.org:C:\\microsip datos\\hconueva.fdb";
//            conns.UserID = "sysdba";
//            conns.Password = "MARCUS";

//            conn = new FirebirdSql.Data.FirebirdClient.FbConnection(conns.ConnectionString);
//            conn.Open();

//            comm.Connection = conn;
//            comm.CommandText = @"SELECT a.docto_cc_id,b.nombre AS cliente,b.contacto1 AS contacto,a.folio,a.fecha,d.fecha_vencimiento,
//                                  c.importe+c.impuesto as importe,coalesce(sum(e.importe)+sum(e.impuesto),0) AS acreditado,
//                                   (c.importe+c.impuesto)-coalesce(sum(e.importe)+sum(e.impuesto),0) AS saldo,
//                                  ' ' as documento_recuperado
//                            FROM
//                                doctos_cc a
//                                INNER JOIN clientes b ON a.cliente_id=b.cliente_id
//                                INNER JOIN importes_doctos_cc c ON a.docto_cc_id=c.docto_cc_id AND tipo_impte='C'
//                                INNER JOIN vencimientos_cargos_cc d ON a.docto_cc_id=d.docto_cc_id
//                                LEFT JOIN importes_doctos_cc e ON a.docto_cc_id=e.docto_cc_acr_id AND e.tipo_impte IN('R','A')
//                            WHERE fecha_vencimiento BETWEEN '{0}' AND '{1}'
//                            GROUP BY a.docto_cc_id,b.nombre,b.contacto1,a.folio,a.fecha,d.fecha_vencimiento,c.importe,c.impuesto
//                            HAVING (c.importe+c.impuesto)-COALESCE(SUM(e.importe)+sum(e.impuesto),0)>0
//                            ORDER BY b.nombre,fecha DESC;";

//            comm.CommandText = string.Format(comm.CommandText, deFecha.ToString("yyyy-MM-dd"), aFecha.ToString("yyyy-MM-dd"));


//            adap.SelectCommand = comm;

//            reader = comm.ExecuteReader();

//            object[] values=new object[10];

            //tCobranza = new DataTable("tCobranza");

            //while (reader.Read()) {

            //    reader.GetValues(values);

            //}



            tCobranza = cc.LoadPronosticoCobranza(deFecha, aFecha);

            grcDatos.DataSource = tCobranza;
            grcDatos.ReloadData();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            exporter.OptionsPrint.PrintHeadersOnEveryPage = true;
            exporter.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;            

            exporter.ExportXlsxToResponse("cobranza"+DateTime.Now.ToString("ddMMyyyy"));
        }

        protected void btnExportar2003_Click(object sender, EventArgs e)
        {
            exporter.OptionsPrint.PrintHeadersOnEveryPage = true;
            exporter.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;

            exporter.ExportXlsToResponse("cobranza" + DateTime.Now.ToString("ddMMyyyy"));
        }


    }
}