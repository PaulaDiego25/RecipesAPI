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
using RecipesAPI.Models;

namespace RecipesAPI.Controllers
{
    public class StepIngredientsController : ApiController
    {
        private RecipesAPIContext db = new RecipesAPIContext();

        // GET: api/StepIngredients
        public IQueryable<StepIngredient> GetStepIngredients()
        {
            return db.StepIngredients;
        }

        // GET: api/StepIngredients/5
        [ResponseType(typeof(StepIngredient))]
        public async Task<IHttpActionResult> GetStepIngredient(int id)
        {
            StepIngredient stepIngredient = await db.StepIngredients.FindAsync(id);
            if (stepIngredient == null)
            {
                return NotFound();
            }

            return Ok(stepIngredient);
        }

        // PUT: api/StepIngredients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStepIngredient(int id, StepIngredient stepIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stepIngredient.Id)
            {
                return BadRequest();
            }

            db.Entry(stepIngredient).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepIngredientExists(id))
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

        // POST: api/StepIngredients
        [ResponseType(typeof(StepIngredient))]
        public async Task<IHttpActionResult> PostStepIngredient(StepIngredient stepIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StepIngredients.Add(stepIngredient);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stepIngredient.Id }, stepIngredient);
        }

        // DELETE: api/StepIngredients/5
        [ResponseType(typeof(StepIngredient))]
        public async Task<IHttpActionResult> DeleteStepIngredient(int id)
        {
            StepIngredient stepIngredient = await db.StepIngredients.FindAsync(id);
            if (stepIngredient == null)
            {
                return NotFound();
            }

            db.StepIngredients.Remove(stepIngredient);
            await db.SaveChangesAsync();

            return Ok(stepIngredient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StepIngredientExists(int id)
        {
            return db.StepIngredients.Count(e => e.Id == id) > 0;
        }
    }
}