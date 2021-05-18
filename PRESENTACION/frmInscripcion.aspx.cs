using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION
{
    public partial class frmInscripcion : System.Web.UI.Page
    {

        /*      METODOS         */
        protected void mostrar()
        {
            Inscripcion insc = new Inscripcion();
            gvInscripcion.DataSource = insc.buscar(txtBuscar.Text);
            gvInscripcion.DataBind();
        }

        protected void mostrarApoderados()
        {
            Apoderado ap = new Apoderado();
            ap.Nombre = txtBuscarAp.Text;
            gvApoderadoModal.DataSource = ap.buscar();
            gvApoderadoModal.DataBind();
        }
        /*  --------------    */

        protected void Page_Load(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtcocGestion.Text = "";
            txtFec.Text = "";
            txtcodEst.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Inscripcion insc = new Inscripcion();
            insc.CodigoCursoGestion = Convert.ToInt32(txtcocGestion.Text);
            insc.Fecha = Convert.ToDateTime(txtFec.Text);
            insc.CodigoEstudiante = Convert.ToInt32(txtcodEst.Text);
            if (insc.guardar()) { lblResp.Text = "Inscripcion Guardada..!"; } else { lblResp.Text = "Error al Registrar"; }
            this.mostrar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Inscripcion insc = new Inscripcion();
            insc.IdInscripcion = Convert.ToInt32(txtIdInscripcion.Text);
            insc.CodigoCursoGestion = Convert.ToInt32(txtcocGestion.Text);
            insc.Fecha = Convert.ToDateTime(txtFec.Text);
            insc.CodigoEstudiante = Convert.ToInt32(txtcodEst.Text);
            if (insc.modificar()) { lblResp.Text = "Inscripcion modificada..!"; } else { lblResp.Text = "Error al modificar"; }
            this.mostrar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Inscripcion insc = new Inscripcion();
            insc.IdInscripcion = Convert.ToInt32(txtIdInscripcion.Text);
            if (insc.eliminar()) { lblResp.Text = "Registro Eliminado..!"; } else { lblResp.Text = "Error al Eliminar"; }
            this.mostrar();
        }

        protected void gvApoderado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void gvInscripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdInscripcion.Text = gvInscripcion.SelectedRow.Cells[0].Text;
            txtcocGestion.Text = gvInscripcion.SelectedRow.Cells[2].Text;
            txtFec.Text = gvInscripcion.SelectedRow.Cells[1].Text;
            txtcodEst.Text = gvInscripcion.SelectedRow.Cells[5].Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void gvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscarApModal(object sender, EventArgs e)
        {
            this.mostrarApoderados();
        }

        protected void btnCerrarApModal(object sender, EventArgs e)
        {

        }
    }
}