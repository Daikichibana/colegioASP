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
    public partial class frmInscripcion : System.Web.UI.Page
    {
        /*  VARIABLES   */
        DataTable detalleApoderado = new DataTable();
        DataTable dtb;
        Estudiante Estu = new Estudiante();

        /*      METODOS         */
        public void CargarDetalle()
        {
            if (Session["detalleDelApoderado"] == null)
            {
                dtb = new DataTable("detalleDelApoderado");
                dtb.Columns.Add("codigo", System.Type.GetType("System.Int32"));
                dtb.Columns.Add("nombre", System.Type.GetType("System.String"));
                dtb.Columns.Add("apellido", System.Type.GetType("System.String"));
                dtb.Columns.Add("telefono", System.Type.GetType("System.String"));
                dtb.Columns.Add("fechaNacimiento", System.Type.GetType("System.DateTime"));
                dtb.Columns.Add("direccion", System.Type.GetType("System.String"));
                

                Session["detalleDelApoderado"] = dtb;
                Session["prueba"] = dtb;
            }
            else
            {
                Session["detalleDelApoderado"] = Session["prueba"];
            }
        }
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

        private bool existeApoderadoEnDetalle(int idAp)
        {
            bool existe = false;
            foreach (GridViewRow row in gvApoderado.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Text) == idAp)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }

        public void AgregarApoderado(int id_apoderado, string nombre, string apellido, string telefono, string direccion, DateTime fecha)
        {
            detalleApoderado = (DataTable) Session["detalleDelApoderado"];
            DataRow fila = detalleApoderado.NewRow();
            fila[0] = id_apoderado;
            fila[1] = nombre;
            fila[2] = apellido;
            fila[3] = telefono;
            fila[4] = fecha;
            fila[5] = direccion;
            
            detalleApoderado.Rows.Add(fila);
            Session["detalleDelApoderado"] = detalleApoderado;
            cargarApoderado();
        }

        public void cargarApoderado()
        {
            gvApoderado.DataSource = Session["detalleDelApoderado"];
            gvApoderado.DataBind();
        }
        /*  --------------    */

        protected void Page_Load(object sender, EventArgs e)
        {
            this.mostrar();
            this.CargarDetalle();
            Session["SeEstudiante"] = new Estudiante();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtcocGestion.Text = "";
            txtFec.Text = "";
            txtcodEst.Text = "";
            Session["detalleDelApoderado"] = null;
            Session["prueba"] = null;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Inscripcion insc = new Inscripcion();
            insc.CodigoCursoGestion = Convert.ToInt32(txtcocGestion.Text);
            insc.Fecha = Convert.ToDateTime(txtFec.Text);
            insc.CodigoEstudiante = Convert.ToInt32(txtcodEst.Text);


            if (insc.guardar()) { lblResp.Text = "Inscripcion Guardada..!"; } else { lblResp.Text = "Error al Registrar"; }


            detalleInscripcion detInsc = new detalleInscripcion();

            foreach (GridViewRow row in gvApoderado.Rows)
            {
                detInsc = new detalleInscripcion();
                detInsc.IdcodApoderado = Convert.ToInt32(row.Cells[0].Text);
                detInsc.Relacion = ((TextBox)row.Cells[6].FindControl("txtQty")).Text;
                detInsc.guardar();
            }

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
            //this.mostrar();

            detalleInscripcion detInsc = new detalleInscripcion();
            detInsc.IdcodInscripcion = Convert.ToInt32(txtIdInscripcion.Text);
            detInsc.eliminar();

            detalleInscripcion dv;
            
            foreach (GridViewRow row in gvApoderado.Rows)
            {
                dv = new detalleInscripcion();
                dv.IdcodApoderado = Convert.ToInt32(row.Cells[0].Text);
                dv.Relacion = ((TextBox)row.Cells[6].FindControl("txtQty")).Text;
                dv.guardar();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            detalleInscripcion detIns = new detalleInscripcion();
            detIns.IdcodInscripcion = Convert.ToInt32(txtIdInscripcion.Text);
            detIns.eliminar();

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
            txtcocGestion.Text = gvInscripcion.SelectedRow.Cells[5].Text;
            txtFec.Text = gvInscripcion.SelectedRow.Cells[1].Text;
            txtcodEst.Text = gvInscripcion.SelectedRow.Cells[2].Text;

            detalleInscripcion detInsc = new detalleInscripcion();
            DataTable detalle = new DataTable();
            detInsc.IdcodInscripcion = Convert.ToInt32(txtIdInscripcion.Text);
            detalle = detInsc.buscar();
            gvApoderado.DataSource = detalle;
            gvApoderado.DataBind();
            Session["prueba"] = detalle;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            modalApoderado.Show();
            gvApoderadoModal.DataBind();
        }

        protected void gvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(gvApoderadoModal.SelectedRow.Cells[0].Text);
            string nombre = gvApoderadoModal.SelectedRow.Cells[1].Text;
            string apellido = gvApoderadoModal.SelectedRow.Cells[2].Text;
            string telefono = gvApoderadoModal.SelectedRow.Cells[3].Text;
            DateTime fecha = Convert.ToDateTime(gvApoderadoModal.SelectedRow.Cells[4].Text);
            string direccion = gvApoderadoModal.SelectedRow.Cells[5].Text;
            

            if (existeApoderadoEnDetalle(Convert.ToInt32(codigo)) == true)
            {
                lblError.Text = "Ya se encuentra agregado";
                modalApoderado.Show();
            }
            else
            {
                AgregarApoderado(codigo, nombre, apellido, telefono, direccion, fecha);
                modalApoderado.Show();
            }
        }

        protected void btnBuscarApModal(object sender, EventArgs e)
        {
            this.mostrarApoderados();
            modalApoderado.Show();
        }

        protected void btnCerrarApModal(object sender, EventArgs e)
        {
            modalApoderado.Hide();

        }

        protected void mostrarEstudiante()
        {
            Estudiante es = new Estudiante();
            es.Nombre = txtBuscarAp.Text;
            gvEstudianteModal.DataSource = es.buscar();
            gvEstudianteModal.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            modalEstudiante.Show();
            gvEstudianteModal.DataBind();
        }

        protected void btnBuscarEstModal(object sender, EventArgs e)
        {
            this.mostrarEstudiante();
            modalEstudiante.Show();
        }
        protected void btnCerrarEstModal(object sender, EventArgs e)
        {
            modalEstudiante.Hide();

        }
        
        public void AgregarEstudiante(int id_estudiante, string nombre, string apellido, string telefono, DateTime fecha, string direccion)
        {
            Estu = (Estudiante)Session["SeEstudiante"];
            Estu.IdEstudiante = id_estudiante;
            Estu.Nombre = nombre;
            Estu.Apellido = apellido;
            Estu.Telefono = telefono;
            Estu.FechaNacimiento = fecha;
            Estu.Direccion = direccion;

            Session["SeEstudiante"] = Estu;

            cargarEstudiante();

            /*
            int codigo = Convert.ToInt32(txtcodEst.Text);
            string nomEst = txtnomEst.Text;
            string apeEst = txtapellEst.Text;
            */
        }
        public void cargarEstudiante()
        {
            txtcodEst.Text = Convert.ToString(Estu.IdEstudiante);
            txtnomEst.Text = Estu.Nombre;
            txtapellEst.Text = Estu.Apellido;
        }
        
        protected void gvCliente2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int codigo = Convert.ToInt32(gvEstudianteModal.SelectedRow.Cells[0].Text);
            string nombre = gvEstudianteModal.SelectedRow.Cells[1].Text;
            string apellido = gvEstudianteModal.SelectedRow.Cells[2].Text;
            string telefono = gvEstudianteModal.SelectedRow.Cells[3].Text;
            DateTime fecha = Convert.ToDateTime(gvEstudianteModal.SelectedRow.Cells[4].Text);
            string direccion = gvEstudianteModal.SelectedRow.Cells[5].Text;
            
            AgregarEstudiante(codigo, nombre, apellido, telefono,fecha,direccion);
            modalEstudiante.Show();
            
        }

        protected void btnBuscarCurso(object sender, EventArgs e)
        {
            modalCurso.Show();
            gvCurso.DataBind();
        }

        protected void btnCerrarCurso(object sender, EventArgs e)
        {
            modalCurso.Hide();
        }

        protected void btnBuscarCusos(object sender, EventArgs e)
        {
            Inscripcion buscaCurso = new Inscripcion();
            gvCurso.DataSource=buscaCurso.buscarCursos(txtBuscarCurso.Text);

           
            gvCurso.DataBind();
            modalCurso.Show();
        }

        protected void gvCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtcocGestion.Text = gvCurso.SelectedRow.Cells[0].Text;
        }

        protected void btnCerrarCalificacion(object sender, EventArgs e)
        {
            modalCalificacion.Hide();
        }

        protected void mostrarCalificaion(object sender, EventArgs e)
        {
            modalCalificacion.Show();
        }

        protected void btnBuscarEstudiante(object sender, EventArgs e)
        {
            detalleCalificacion detalleCali = new detalleCalificacion();
            gvCalificacion.DataSource = detalleCali.buscarPorNombreApellidos(txtNombreEstudiante.Text, txtApellidosEstudiante.Text);
            gvCalificacion.DataBind();
            modalCalificacion.Show();
        }
    }
}