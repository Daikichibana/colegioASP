namespace NEGOCIO
{
    using System;
    using System.Data;
    using DATOS;
    public class Apoderado : Conexion
    {
        private int codigo;
        private string nombre;
        private string apellido;
        private string telefono;
        private DateTime fechaNacimiento;
        private string direccion;

        public Apoderado()
        {
            codigo = 0;
            nombre = "";
            apellido = "";
            telefono = "";
            fechaNacimiento = DateTime.Today.Date;
            direccion = "";
        }

        public int IdApoderado
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }


        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }


        public DateTime FechaNacimiento
        {
            get { return this.fechaNacimiento; }
            set { this.fechaNacimiento = value; }
        }
        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }

        ///Metodos CRUD
        public bool guardar()
        {
            iniciarSP("guardarApoderado");
            parametroVarchar(nombre, "nom", 30);
            parametroVarchar(apellido, "ape", 30);
            parametroVarchar(telefono, "tel", 10);
            parametroVarchar(direccion, "dir", 10);
            parametroFecha(FechaNacimiento, "fec");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar()
        {
            iniciarSP("buscarApoderado");
            parametroVarchar(nombre, "buscar", 30);
            return mostrarData();
        }

        public bool modificar()
        {
            iniciarSP("modificarApoderado");
            parametroInt(codigo, "id_apo");
            parametroVarchar(nombre, "nom", 30);
            parametroVarchar(apellido, "ape", 30);
            parametroVarchar(telefono, "tel", 10);
            parametroVarchar(direccion, "dir", 10);
            parametroFecha(FechaNacimiento, "fec");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool eliminar()
        {
            iniciarSP("eliminarApoderado");
            parametroInt(codigo, "id_apo");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable selectEstudiante()
        {
            iniciarSP("selectApoderado");
            return mostrarData();
        }
    }
}
