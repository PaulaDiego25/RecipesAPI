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
    public class StepsController : ApiController
    {
        private RecipesAPIContext db = new RecipesAPIContext();

        // GET: api/Steps
        public IQueryable<Step> GetSteps()
        {
            return db.Steps;
        }

        // GET: api/Steps/5
        [ResponseType(typeof(Step))]
        public async Task<IHttpActionResult> GetStep(int id)
        {
            Step step = await db.Steps.FindAsync(id);
            if (step == null)
            {
                return NotFound();
            }

            return Ok(step);
        }

        // GET: api/StepsByRecipe/5
        [Route("api/StepsByRecipe")]
        public IQueryable<Step> GetStepsByRecipe(int id)
        {
            return db.Steps.Where(c => c.FKRecipe.Id == id).OrderBy(c => c.Order);
        }

        // GET: api/NewStepOrder/5
        [Route("api/NewStepOrder")]
        public int GetNewStepOrder(int id)
        {
            return db.Steps.Count(c => c.FKRecipe.Id == id) + 1;
        }

        // PUT: api/Steps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStep(int id, Step step)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != step.Id)
            {
                return BadRequest();
            }

            db.Entry(step).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepExists(id))
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

        // POST: api/Steps
        [ResponseType(typeof(Step))]
        public async Task<IHttpActionResult> PostStep(Step step)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Steps.Add(step);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = step.Id }, step);
        }

        // DELETE: api/Steps/5
        [ResponseType(typeof(Step))]
        public async Task<IHttpActionResult> DeleteStep(int id)
        {
            Step step = await db.Steps.FindAsync(id);
            if (step == null)
            {
                return NotFound();
            }

            db.Steps.Remove(step);
            await db.SaveChangesAsync();

            return Ok(step);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StepExists(int id)
        {
            return db.Steps.Count(e => e.Id == id) > 0;
        }
    }
}