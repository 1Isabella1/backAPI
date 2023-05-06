using backAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Cors;

namespace backAPI.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly string conectSQL;

        public EstudianteController(IConfiguration confi)
        {
            conectSQL = confi.GetConnectionString("ConectSQL");
        }

        [HttpGet]
        [Route("ListaEstudiante")]
        public IActionResult ListaEstudiante()
        {
            List<Estudiante> oListaEstudiante = new List<Estudiante>();
            try
            {
                using (var conexion = new SqlConnection(conectSQL))
                    
                {
                    

                    conexion.Open();
                    var cmd = new SqlCommand("ListarEstudiantes", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        
                        while (dr.Read())
                        {
                            oListaEstudiante.Add(new Estudiante()
                            {
                                Identificacion = dr["Identificacion"].ToString(),
                                Nombre1 = dr["Nombre1"].ToString(),
                                Apellido1 = dr["Apellido1"].ToString(),
                                Email = dr["Email"].ToString(),
                            });
                        }

                    }

                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "okEst", response = oListaEstudiante });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = oListaEstudiante });
                    
            }



        }

    }
}
