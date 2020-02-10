using System;

namespace Model
{
    [Serializable]
    public class PersonModel
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaDeNacimiento { get; set; }
        public string Cuidad { get; set; }
        public string EstadoDeNacimiento { get; set; }
        public string Pais { get; set; }
        public string Nacionalidad { get; set; }
        public string FormaMigratoria { get; set; }
        public string Sexo { get; set; }
        public string TipoDeSangre { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Municipio { get; set; }
        public string EstadoDeResidencia { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoOficina { get; set; }
        public string CorreoElectronico { get; set; }
        public string CodigoDeEmpleado { get; set; }
        public string Curp { get; set; }
        public string NumeroDeSeguridadSocial { get; set; }
        public string NumeroDeAfore { get; set; }
        public string InstitucionDeLaAfore { get; set; }
        public string RFC { get; set; }

        public PersonModel()
        {
        }

        public PersonModel(
            string nombre = "no_data", string apellidoPaterno = "no_data", 
            string apellidoMaterno = "no_data", string fechaDeNacimiento = "no_data", 
            string cuidad = "no_data", string estadoDeNacimiento = "no_data", 
            string pais = "no_data", string nacionalidad = "no_data", string formaMigratoria = "no_data"
            , string sexo = "no_data", string tipoDeSangre = "no_data", 
            string calle = "no_data", string numeroExterior = "no_data", 
            string numeroInterior = "no_data", string colonia = "no_data", 
            string codigoPostal = "no_data", string municipio = "no_data", 
            string estadoDeResidencia = "no_data", string telefonoCelular = "no_data", 
            string telefonoOficina = "no_data", string correoElectronico = "no_data", 
            string codigoDeEmpleado = "no_data", string curp = "no_data", 
            string numeroDeSeguridadSocial = "no_data", string numeroDeAfore = "no_data", 
            string institucionDeLaAfore = "no_data", string rfc = "no_data"
            )
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            FechaDeNacimiento = fechaDeNacimiento;
            Cuidad = cuidad;
            EstadoDeNacimiento = estadoDeNacimiento;
            Pais = pais;
            Nacionalidad = nacionalidad;
            FormaMigratoria = formaMigratoria;
            Sexo = sexo;
            TipoDeSangre = tipoDeSangre;
            Calle = calle;
            NumeroExterior = numeroExterior;
            NumeroInterior = numeroInterior;
            Colonia = colonia;
            CodigoPostal = codigoPostal;
            Municipio = municipio;
            EstadoDeResidencia = estadoDeResidencia;
            TelefonoCelular = telefonoCelular;
            TelefonoOficina = telefonoOficina;
            CorreoElectronico = correoElectronico;
            CodigoDeEmpleado = codigoDeEmpleado;
            Curp = curp;
            NumeroDeSeguridadSocial = numeroDeSeguridadSocial;
            NumeroDeAfore = numeroDeAfore;
            InstitucionDeLaAfore = institucionDeLaAfore;
            RFC = rfc;
        }
    }
}
