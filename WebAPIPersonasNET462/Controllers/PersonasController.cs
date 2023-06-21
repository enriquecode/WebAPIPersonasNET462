using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIPersonasNET462.Models;
using System.Data;
using DataLayer;
using System.Data.SqlClient;


namespace WebAPIPersonasNET462.Controllers
{
    public class PersonasController : ApiController
    {

        [HttpGet]
        public IHttpActionResult ObtenerPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();

            DataAccess dataAccess = new DataAccess();
            DataTable dt = new DataTable();

            dt = dataAccess.ObtenPersonas();

            foreach (DataRow dr in dt.Rows)
            {
                listaPersonas.Add(new Persona
                {
                    id = Convert.ToInt32(dr["id"].ToString()),
                    Nombre = dr["Nombre"].ToString(),
                    Edad = Convert.ToInt32(dr["Edad"].ToString()),
                    Email = dr["EMail"].ToString(),
                });

            }

            IList<Persona> IListaPersonas = listaPersonas.Cast<Persona>().ToList();
            return Ok(IListaPersonas);
        }

        [HttpPost]
        public IHttpActionResult InsertarPersona(Persona persona)
        {

            SqlParameter[] sqlparam = new SqlParameter[4];

            sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[0].SqlValue = 0;

            sqlparam[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
            sqlparam[1].SqlValue = persona.Nombre;

            sqlparam[2] = new SqlParameter("@Edad", SqlDbType.SmallInt);
            sqlparam[2].SqlValue = persona.Edad;

            sqlparam[3] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlparam[3].SqlValue = persona.Email;

            DataAccess dataAccess = new DataAccess();
            int resultadoDB = 0;
            resultadoDB = dataAccess.InsertarPersona(sqlparam);

            if (resultadoDB == 1)
                return Ok();
            else
                return BadRequest(ModelState);  
        }

    }
}
