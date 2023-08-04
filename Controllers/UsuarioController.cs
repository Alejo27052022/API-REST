using ClienteRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Web.Mvc;

namespace ClienteRest.Controllers
{
    public class UsuarioController :  ApiController
    {
        //GET
        public IEnumerable<Models.Usuarios> Get()
        {
            IEnumerable<Models.Usuarios> lst;

            using (Models.DB_IntComexEntities2 db = new Models.DB_IntComexEntities2())
            {
                lst = db.Usuarios.ToList();
            }

            return lst;
        }

        public Models.Usuarios Get(int id)
        {
            using (Models.DB_IntComexEntities2 db = new Models.DB_IntComexEntities2())
            {
                Models.Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

                if(usuario == null)
                {
                    throw new ArgumentException("No se encontro ningun usuario con el ID especificado");
                }

                return usuario;
            }
        }

        public IHttpActionResult Post([FromBody] Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                using (DB_IntComexEntities2 db = new DB_IntComexEntities2())
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                }
                return Ok(usuario);
            }
            else
            {
                return BadRequest("Datos inválidos");
            }
        }

        public IHttpActionResult Put(int id, [FromBody] Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                using (DB_IntComexEntities2 db = new DB_IntComexEntities2())
                {
                    Usuarios existingUsuario = db.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

                    if (existingUsuario == null)
                    {
                        return NotFound();
                    }

                    existingUsuario.Nombre1 = usuario.Nombre1;
                    existingUsuario.Nombre2 = usuario.Nombre2;
                    existingUsuario.Apellido1 = usuario.Apellido1;
                    existingUsuario.Apellido2 = usuario.Apellido2;
                    existingUsuario.FechaNacimiento = usuario.FechaNacimiento;
                    existingUsuario.Email = usuario.Email;
                    existingUsuario.Direccion = usuario.Direccion;
                    existingUsuario.Telefono = usuario.Telefono;
                    // Agrega más propiedades según tus necesidades.

                    db.SaveChanges();
                }

                return Ok(usuario);
            }
            else
            {
                return BadRequest("Datos inválidos");
            }
        }

        public IHttpActionResult Delete(int id)
        {
            using (DB_IntComexEntities2 db = new DB_IntComexEntities2())
            {
                Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

                if (usuario == null)
                {
                    return NotFound();
                }

                db.Usuarios.Remove(usuario);
                db.SaveChanges();

                return Ok(usuario);
            }
        }

    }
}
