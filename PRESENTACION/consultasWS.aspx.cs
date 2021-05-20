using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION
{
    public partial class consultasWS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarCurso_Click(object sender, EventArgs e)
        {
           
           wsColegio.wsColegio obj = new wsColegio.wsColegio();
           gdvCurso.DataSource = obj.buscarCursoPorNombre(txtBuscarCur.Text);
           gdvCurso.DataBind();
        }

        protected void txtBuscarCur_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscarInsc_Click(object sender, EventArgs e)
        {
            wsColegio.wsColegio obj = new wsColegio.wsColegio();
            gdvInscripcion.DataSource = obj.buscarInscripcionPorNombreEstudiante(txtBuscarInsc.Text);
            gdvInscripcion.DataBind();
        }

        protected void txtBuscarInsc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}