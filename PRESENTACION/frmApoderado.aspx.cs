using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION
{
    public partial class frmApoderado : System.Web.UI.Page
    {

        /*      METODOS         */
        protected void mostrar()
        {
            Apoderado ap = new Apoderado();
            ap.Nombre = txtBuscar.Text;
            gvApoderado.DataSource = ap.buscar();
            gvApoderado.DataBind();
        }
        /*  --------------    */


        protected void Page_Load(object sender, EventArgs e)
        {
            mostrar();
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblResp.Text = "";
            txtBuscar.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Apoderado ap = new Apoderado();
            ap.Nombre = txtNombre.Text;
            ap.Apellido = txtApellido.Text;
            ap.FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            ap.Telefono = txtTelefono.Text;
            ap.Direccion = txtDireccion.Text;
            if (ap.guardar()) { lblResp.Text = "Apoderado Guardado..!"; } else { lblResp.Text = "Error al Registrar"; }
            this.mostrar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Apoderado ap = new Apoderado();
            ap.IdApoderado = Convert.ToInt32(txtIdApoderado.Text);
            ap.Nombre = txtNombre.Text;
            ap.Apellido = txtApellido.Text;
            ap.FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            ap.Telefono = txtTelefono.Text;
            ap.Direccion = txtDireccion.Text;
            if (ap.modificar()) { lblResp.Text = "Registro Modificado..!"; } else { lblResp.Text = "Error al Modificar"; }
            this.mostrar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Apoderado ap = new Apoderado();
            ap.IdApoderado = Convert.ToInt32(txtIdApoderado.Text);
            if (ap.eliminar()) { lblResp.Text = "Registro Eliminado..!"; } else { lblResp.Text = "Error al Eliminar"; }
            this.mostrar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void gvApoderado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdApoderado.Text = gvApoderado.SelectedRow.Cells[0].Text;
            txtNombre.Text = gvApoderado.SelectedRow.Cells[1].Text;
            txtApellido.Text = gvApoderado.SelectedRow.Cells[2].Text;
            txtDireccion.Text = gvApoderado.SelectedRow.Cells[3].Text;
            txtFecha.Text = gvApoderado.SelectedRow.Cells[4].Text;
            txtTelefono.Text = gvApoderado.SelectedRow.Cells[5].Text;
        }
    }
}