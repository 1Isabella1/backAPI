using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using backAPI.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Cors;

namespace backAPI.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly string conectSQL;

        public CursoController(IConfiguration confi)
        {
            conectSQL = confi.GetConnectionString("ConectSQL");
        }

        [HttpGet]
        [Route("ListaCurso")]
        public IActionResult ListaCurso()
        {
            List<Curso> oListaCursos = new List<Curso>();

            try
            {
                using (var conexion = new SqlConnection(conectSQL)) { 
                
                    conexion.Open();
                    var cmd = new SqlCommand("ListarCursos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaCursos.Add(new Curso()
                            {
                                NombreCurso = dr["NombreCurso"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                            });
                        }

                    }

                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "okCurso", response = oListaCursos });
            }
            catch (Exception error) {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = oListaCursos });

            }



        }

    }

    
}
