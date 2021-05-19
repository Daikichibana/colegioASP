namespace NEGOCIO
{
    using System;
    using System.Data;
    using DATOS;

    public class detalleCalificacion : Conexion
    {
        private int codigo;
        private int notaSer;
        private int notaSaber;
        private int notaHacer;
        private int notaDecidir;

        public detalleCalificacion()
        {
            this.notaSer = 0;
            this.notaSaber = 0;
            this.notaHacer = 0;
            this.notaDecidir = 0;
        }

        public int CodDetalle
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        public int NSer
        {
            get { return this.notaSer; }
            set { this.notaSer = value; }
        }

        public int NSaber
        {
            get { return this.notaSaber; }
            set { this.notaSaber = value; }
        }

        public int NHacer
        {
            get { return this.notaHacer; }
            set { this.notaHacer = value; }
        }

        public int NDecidir
        {
            get { return this.notaDecidir; }
            set { this.notaDecidir = value; }
        }


        //metodos CRUD

        public bool guardar()
        {
            //introMetodo
            return false;
        }

        public DataTable buscarPorCodigo(string nomEst)
        {
            //introMetodo
            return null;
        }

        public DataTable buscarPorNombreApellidos(string nomEst, string apeEst)
        {
            iniciarSP("buscarPorNyA");
            parametroVarchar(nomEst, "nombre", 30);
            parametroVarchar(apeEst, "apellido", 30);
            return mostrarData();
        }

        public bool modificar()
        {
            //introMetodo
            return false;
        }
        public bool eliminar()
        {
            //introMetodo
            return false;
        }

    }
}
