using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Entity;
using System.Linq;

namespace DAL
{
    public class PersonaRepository 
    {
        private SqlConnection _connection;
        private List<Persona> _personas;

        public PersonaRepository(ConectionManager conection)
        {
            _connection = conection._connection;
            _personas = new List<Persona>();
        }

        public void GuardarPersona(Persona persona)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Personas(Identificacion,Nombre,Sexo,Edad,Departamento,Ciudad,ValorApoyo,Modalidad,Fecha)Values"+
                    "(@Identificacion,@Nombre,@Sexo,@Edad,@Departamento,@Ciudad,@ValorApoyo,@Modalidad,@Fecha)";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                command.Parameters.AddWithValue("@Edad", persona.Edad);
                command.Parameters.AddWithValue("@Departamento", persona.Departamento);
                command.Parameters.AddWithValue("@Ciudad", persona.Ciudad);
                command.Parameters.AddWithValue("@ValorApoyo", persona.ValorApoyo);
                command.Parameters.AddWithValue("@Modalidad", persona.Modalidad);
                command.Parameters.AddWithValue("@Fecha", persona.Fecha);
                command.ExecuteNonQuery();
            }
        }

        public List<Persona> Consultar()
        {
            SqlDataReader dataReader;
            _personas.Clear();
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Personas";
                dataReader = command.ExecuteReader();
                if(dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        Persona persona = MapearPersona(dataReader);
                        _personas.Add(persona);
                    }
                }
            }
            return _personas;
        }

        private Persona MapearPersona(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Persona persona = new Persona();
            persona.Identificacion = (string)dataReader["Identificacion"];
            persona.Nombre = (string)dataReader["Nombre"];
            persona.Sexo = (string)dataReader["Sexo"];
            persona.Edad = (int)dataReader["Edad"];
            persona.Departamento = (string)dataReader["Departamento"];
            persona.Ciudad = (string)dataReader["Ciudad"];
            persona.ValorApoyo = (decimal)dataReader["ValorApoyo"];
            persona.Modalidad = (string)dataReader["Modalidad"];
            persona.Fecha = (DateTime)dataReader["Fecha"];
            return persona;
        }

        public decimal SumaAyudas()
        {
            return Consultar().Sum(p =>p.ValorApoyo);
        }

        
        public Persona BuscarPersona(string id)
        {
            return Consultar().Find(p => p.Identificacion == id);
        }
    }
}