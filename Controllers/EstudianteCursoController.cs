using backAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Cors;
using System;

namespace backAPI.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteCursoController : ControllerBase
    {
        private readonly string conectSQL;

        public EstudianteCursoController(IConfiguration confi)
        {
            conectSQL = confi.GetConnectionString("ConectSQL");
        }

        [HttpGet]
        [Route("ListaECurso/{Identificacion}")]
        public IActionResult ListaECurso(string Identificacion)
        {

            List<Curso> oListaECursos = new List<Curso>();

            try
            {
  
                using (var conexion = new SqlConnection(conectSQL))
                {

                    conexion.Open();
                    var cmd = new SqlCommand("ListarECursos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Identificacion", Identificacion);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaECursos.Add(new Curso()
                            {
                                
                                NombreCurso = dr["NombreCurso"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                            });
                        }

                    }

                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "okestCu", response = oListaECursos });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = oListaECursos });

            }



        }

        [HttpPost]
        [Route("Agregar")]
        public IActionResult Agregar([FromBody] EstudianteCurso objeto)
        {

            try
            {
                using (var conexion = new SqlConnection(conectSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_InsertarEstudianteCurso", conexion);
                    cmd.Parameters.AddWithValue("identificacion", objeto.Identificacion);
                    cmd.Parameters.AddWithValue("nombreCurso", objeto.NombreCurso);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "okestCu"});
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }



        }

        [HttpDelete]
        [Route("Borrar")]
        public IActionResult Borrar([FromBody] EstudianteCurso objeto)
        {

            try
            {
                using (var conexion = new SqlConnection(conectSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_BorrarEstudianteCurso", conexion);
                    cmd.Parameters.AddWithValue("identificacion", objeto.Identificacion);
                    cmd.Parameters.AddWithValue("nombreCurso", objeto.NombreCurso);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "eliminado" });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }



        }
    }
}
