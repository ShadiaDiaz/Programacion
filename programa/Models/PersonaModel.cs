


namespace Programa.Models
{

    using System;
    using Entity;
    public class PersonaInputModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public decimal ValorApoyo { get; set; }
        public string  Modalidad { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }

        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            Sexo = persona.Sexo;
            Edad = persona.Edad;
            Departamento = persona.Departamento;
            Ciudad = persona.Ciudad;
            ValorApoyo= persona.ValorApoyo;
            Modalidad = persona.Modalidad;
            Fecha = persona.Fecha;
        }
    }
}