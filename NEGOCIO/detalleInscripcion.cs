namespace NEGOCIO
{
    using System;
    using System.Data;
    using DATOS;
    public class detalleInscripcion : Conexion
    {
        private int codInscripcion;
        private int codApoderado;
        private string relacion;

        public detalleInscripcion()
        {
            codInscripcion = 0;
            codApoderado = 0;
            relacion = "";
        }

        public int IdcodInscripcion
        {
            get { return this.codInscripcion; }
            set { this.codInscripcion = value; }
        }

        public int IdcodApoderado
        {
            get { return this.codApoderado; }
            set { this.codApoderado = value; }
        }

        public string Relacion
        {
            get { return this.relacion; }
            set { this.relacion = value; }
        }



        ///Metodos CRUD
        public bool guardar()
        {
            iniciarSP("guardarDetalleInscripcion");
            parametroInt(codApoderado,"codAp");
            parametroVarchar(relacion, "rel", 30);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar()
        {
            iniciarSP("buscarDetalleInscripcion");
            parametroInt(codInscripcion, "codInsc");
            return mostrarData();
        }

        /*
        public bool modificar()
        {
            iniciarSP("modificarDetalleInscripcion");
            parametroInt(codInscripcion, "codInsc");
            parametroInt(codApoderado, "codAp");
            parametroVarchar(relacion, "rel", 30);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        */

        public bool eliminar()
        {
            iniciarSP("eliminarDetalleInscripcion");
            parametroInt(codInscripcion, "codInsc");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable selectDetalleInscripcion()
        {
            iniciarSP("selectDetalleInscripcion");
            return mostrarData();
        }
    }
}
