using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PeopleTracker.DAL;

namespace PeopleTracker.NetService.Controllers
{
   public class PeopleController : ApiController
   {
      private Models db = new Models();

      /// <summary>
      /// GET: api/People
      /// </summary>
      /// <returns></returns>
      public IQueryable<Person> GetPeople()
      {
         return db.People;
      }

      /// <summary>
      /// GET: api/People/5
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [ResponseType(typeof(Person))]
      public async Task<IHttpActionResult> GetPerson(int id)
      {
         Person person = await db.People.FindAsync(id);
         if (person == null)
         {
            return NotFound();
         }

         return Ok(person);
      }

      /// <summary>
      /// PUT: api/People/5
      /// </summary>
      /// <param name="id"></param>
      /// <param name="person"></param>
      /// <returns></returns>
      [ResponseType(typeof(void))]
      public async Task<IHttpActionResult> PutPerson(int id, Person person)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         if (id != person.ID)
         {
            return BadRequest();
         }

         db.Entry(person).State = EntityState.Modified;

         try
         {
            await db.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            if (!PersonExists(id))
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

      /// <summary>
      /// POST: api/People
      /// </summary>
      /// <param name="person"></param>
      /// <returns></returns>
      [ResponseType(typeof(Person))]
      public async Task<IHttpActionResult> PostPerson(Person person)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         db.People.Add(person);
         await db.SaveChangesAsync();

         return CreatedAtRoute("DefaultApi", new { id = person.ID }, person);
      }

      /// <summary>
      /// DELETE: api/People/5
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [ResponseType(typeof(Person))]
      public async Task<IHttpActionResult> DeletePerson(int id)
      {
         Person person = await db.People.FindAsync(id);
         if (person == null)
         {
            return NotFound();
         }

         db.People.Remove(person);
         await db.SaveChangesAsync();

         return Ok(person);
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            db.Dispose();
         }
         base.Dispose(disposing);
      }

      private bool PersonExists(int id)
      {
         return db.People.Count(e => e.ID == id) > 0;
      }
   }
}