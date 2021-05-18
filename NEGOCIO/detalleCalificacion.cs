namespace NEGOCIO
{
    using System;
    using System.Data;
    using DATOS;

    class detalleCalificacion
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
    }
}
