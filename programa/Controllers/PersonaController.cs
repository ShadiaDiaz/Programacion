using Microsoft.AspNetCore.Mvc;
using Bll;
using Microsoft.Extensions.Configuration;
using Entity;
using Programa.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

[Route("api/[controller]")]
[ApiController]

public class PersonaController : ControllerBase
{
    private readonly PersonaService service;

    public IConfiguration Configuration { get; }

    public PersonaController(IConfiguration configuration)
    {
        Configuration = configuration;
        string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        service = new PersonaService(connectionString);
    }


        // GET: api/Persona​
        [HttpGet]
       public ActionResult<PersonaViewModel> Gets()
        {
            var response = service.Consultar();
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Personas.Select(p=> new PersonaViewModel(p)));
        }

        

    //Post: Api/Persona

    [HttpPost]
   public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput){


        Persona persona   =  MapearPersona(personaInput);
        var response = service.Guardar(persona);  
        if(response.Error){
            return BadRequest(response.Mensaje);
        } 
        return Ok(response.Persona);
  }
    private Persona MapearPersona(PersonaInputModel personaInput)
    {
        var persona = new Persona
        {
            Identificacion = personaInput.Identificacion,
            Nombres = personaInput.Nombres,
            Sexo = personaInput.Sexo,
            Edad = personaInput.Edad,
            Departamento = personaInput.Departamento,
            Ciudad = personaInput.Ciudad,
            ValorApoyo = personaInput.ValorApoyo,
            Modalidad = personaInput.Modalidad,
            Fecha = personaInput.Fecha
        };
        return persona;
    }
}

