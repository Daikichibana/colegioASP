namespace NEGOCIO
{
    using System;
    using System.Data;
    using DATOS;

    public class Inscripcion : Conexion
    {

        private DateTime fec;
        private int codcGestion;
        private int codEst;
        private int id_insc;
        public Inscripcion()
        {
            id_insc = 0;  
            fec = DateTime.Today.Date;
            codcGestion = 0;
            codEst = 0;
        }
        public int IdInscripcion
        {
            get { return this.id_insc; }
            set { this.id_insc = value; }
        }
        public DateTime Fecha
        {
            get { return this.fec; }
            set { this.fec = value; }
        }
        public int CodigoCursoGestion
        {
            get { return this.codcGestion; }
            set { this.codcGestion = value; }
        }
        public int CodigoEstudiante
        {
            get { return this.codEst; }
            set { this.codEst = value; }
        }

        ///Metodos CRUD
        public bool guardar()
        {
            iniciarSP("guardarInscripcion");
            parametroInt(IdInscripcion, "id:insc");
            parametroFecha(Fecha, "fec");
            parametroInt(CodigoCursoGestion, "codcGestion");
            parametroInt(CodigoEstudiante, "codEst");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar(string nomEst)
        {
            iniciarSP("buscarInscripcionNombreEstudiante");
            parametroVarchar(nomEst, "buscar", 30);
            return mostrarData();
        }

        public bool modificar()
        {
            iniciarSP("modificarInscripcion");
            parametroInt(IdInscripcion, "id:insc");
            parametroFecha(Fecha, "fec");
            parametroInt(CodigoCursoGestion, "codcGestion");
            parametroInt(CodigoEstudiante, "codEst");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool eliminar()
        {
            iniciarSP("eliminarInscripcion");
            parametroInt(IdInscripcion, "id_insc");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable selectInscripcion()
        {
            iniciarSP("selectInscripcion");
            return mostrarData();
        }

        public DataTable buscarCursos(string nCurso)
        {
            iniciarSP("buscarCursos");
            parametroVarchar(nCurso, "buscar", 30);
            return mostrarData();
        }
    }
}
