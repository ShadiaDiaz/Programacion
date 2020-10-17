using System;
using Entity;
using DAL;
using System.Collections.Generic;

namespace Bll
{
    public class PersonaService
    {
        private readonly ConectionManager _connection;
        private readonly PersonaRepository _repositorio;

        public PersonaService(string connection)
        {
            _connection = new ConectionManager(connection);
            _repositorio = new PersonaRepository(_connection);
        }

        public GuardarPersonaResponse Guardar(Persona persona)
        {
            string mensaje = "";
            try
            {
                _connection.Open();
                if (_repositorio.BuscarPersona(persona.Identificacion) == null)
                {
                    if ((_repositorio.SumaAyudas() + persona.ValorApoyo) > 60000000)
                    {
                        mensaje = "Error: El ValorApoyo de las ayudas se excede. ";
                        _connection.Close();
                        return new GuardarPersonaResponse(mensaje);
                    }
                    else
                    {
                        mensaje = "Se ha guardado correctamente la persona. ";
                        _repositorio.GuardarPersona(persona);
                        _connection.Close();
                        return new GuardarPersonaResponse(mensaje,persona);
                    }
                }
                else
                {
                    mensaje = "Error: La persona ya se encuentra registrada :c. ";
                    _connection.Close();
                    return new GuardarPersonaResponse(mensaje);
                }
            }
            catch(Exception e)
            {
                _connection.Close();
                return new GuardarPersonaResponse($"Error en la aplicacion: {e.Message}");
            }
        }

        public decimal TotalAyudas()
        {
            decimal total= 0;
            _connection.Open();
            total = _repositorio.SumaAyudas();
            _connection.Close();
            return total;
        }

       

        public PersonaConsultaResponse Consultar()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                _connection.Open();
                personas = _repositorio.Consultar();
                _connection.Close();
                return new PersonaConsultaResponse(personas);
            }
            catch(Exception e)
            {
                _connection.Close();
                return new PersonaConsultaResponse($"Error en la aplicacion: {e.Message}");
            }
        }
        public class GuardarPersonaResponse
        {
            public GuardarPersonaResponse(string mensaje, Persona persona)
            {
                Error = false;
                Mensaje = mensaje;
                Persona = persona;
            }

            public GuardarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
        
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Persona Persona { get; set; }
        }

        public class PersonaConsultaResponse
        {
            public PersonaConsultaResponse(List<Persona> personas)
            {
                Error = false;
                Personas = personas;
            }

            public PersonaConsultaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Persona> Personas { get; set; }
        }
    }
}