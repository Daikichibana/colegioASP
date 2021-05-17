using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION
{
    public partial class estudiante : System.Web.UI.Page
    {

        /*      METODOS         */
        protected void mostrar()
        {
            Estudiante est = new Estudiante();
            est.Nombre = txtBuscar.Text;
            gvEstudiante.DataSource = est.buscar();
            gvEstudiante.DataBind();
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
            Estudiante est = new Estudiante();
            est.Nombre = txtNombre.Text;
            est.Apellido = txtApellido.Text;
            est.FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            est.Telefono = txtTelefono.Text;
            est.Direccion = txtDireccion.Text;
            if (est.guardar()) { lblResp.Text = "Estudiante Guardado..!"; } else { lblResp.Text = "Error al Registrar"; }
            this.mostrar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Estudiante est = new Estudiante();
            est.IdEstudiante = Convert.ToInt32(txtIdestudiante.Text);
            est.Nombre = txtNombre.Text;
            est.Apellido = txtApellido.Text;
            est.FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            est.Telefono = txtTelefono.Text;
            est.Direccion = txtDireccion.Text;
            if (est.modificar()) { lblResp.Text = "Registro Modificado..!"; } else { lblResp.Text = "Error al Modificar"; }
            this.mostrar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Estudiante est = new Estudiante();
            est.IdEstudiante = Convert.ToInt32(txtIdestudiante.Text);
            if (est.eliminar()) { lblResp.Text = "Registro Eliminado..!"; } else { lblResp.Text = "Error al Eliminar"; }
            this.mostrar();
        }

        protected void gvEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdestudiante.Text = gvEstudiante.SelectedRow.Cells[0].Text;
            txtNombre.Text = gvEstudiante.SelectedRow.Cells[1].Text;
            txtApellido.Text = gvEstudiante.SelectedRow.Cells[2].Text;
            txtDireccion.Text = gvEstudiante.SelectedRow.Cells[3].Text;
            txtFecha.Text = gvEstudiante.SelectedRow.Cells[4].Text;
            txtTelefono.Text = gvEstudiante.SelectedRow.Cells[5].Text;
        }
    }
}