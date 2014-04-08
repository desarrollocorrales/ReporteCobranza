using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ControlBusinessLayer;

namespace ACCControlWeb
{
    public partial class ControlAcc : System.Web.UI.MasterPage
    {
        public string Conexion
        {
            get
            {
                if (cmbConexion.SelectedItem != null)
                {
                    return cmbConexion.SelectedItem.ToString();
                }
                else 
                { 
                    return string.Empty; 
                }
            }
        }

        public void SetVisible(bool Visible, params string[] controls)
        {
            foreach (string control in controls)
            {
                this.FindControl(control).Visible = Visible;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("loggin.aspx", true);
        }

        protected void cmbConexion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}