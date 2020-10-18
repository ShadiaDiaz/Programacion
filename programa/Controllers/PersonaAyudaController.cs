namespace programa.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Bll;
    using Microsoft.Extensions.Configuration;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonaAyudaController: ControllerBase

    {

          private readonly PersonaService service;

        public IConfiguration Configuration { get; }

        public PersonaAyudaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            service = new PersonaService(connectionString);
        }

        
        [HttpGet]
        public ActionResult<int> GetSumaAyudas()
        {
            var response = service.SumaAyudas();
            return Ok(response);
        }
        


    }
}