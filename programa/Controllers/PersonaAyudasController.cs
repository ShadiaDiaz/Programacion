    using Microsoft.AspNetCore.Mvc;
    using Bll;
    using Microsoft.Extensions.Configuration;
namespace programa.Controllers
{
    public class PersonaAyudasController
    {
        [Route("api/[controller]")]
        [ApiController]
        private readonly PersonaService service;

        public IConfiguration Configuration { get; }

        public PersonaAyudasController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            service = new PersonaService(connectionString);
        }
 //GET: Api/PersonasTotalAyudas
        [HttpGet]
        public ActionResult<decimal> GetSumaAyudas()
        {
            var response = service.SumaAyudas();
            return Ok(response);
        }
        
    }
}