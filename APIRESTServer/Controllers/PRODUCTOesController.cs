using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIRESTServer.Models;

namespace APIRESTServer.Controllers
{
    public class PRODUCTOesController : ApiController
    {
        private ORACLEDOCKEREntities db = new ORACLEDOCKEREntities();

        // GET: api/PRODUCTOes
        public IQueryable<PRODUCTO> GetPRODUCTOS()
        {
            return db.PRODUCTOS;
        }

        // GET: api/PRODUCTOes/5
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult GetPRODUCTO(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTOS.Find(id);
            if (pRODUCTO == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTO);
        }

        // PUT: api/PRODUCTOes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRODUCTO(int id, PRODUCTO pRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCTO.CODIGO)
            {
                return BadRequest();
            }

            db.Entry(pRODUCTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PRODUCTOes
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult PostPRODUCTO(PRODUCTO pRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTOS.Add(pRODUCTO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pRODUCTO.CODIGO }, pRODUCTO);
        }

        // DELETE: api/PRODUCTOes/5
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult DeletePRODUCTO(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTOS.Find(id);
            if (pRODUCTO == null)
            {
                return NotFound();
            }

            db.PRODUCTOS.Remove(pRODUCTO);
            db.SaveChanges();

            return Ok(pRODUCTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTOExists(int id)
        {
            return db.PRODUCTOS.Count(e => e.CODIGO == id) > 0;
        }
    }
}