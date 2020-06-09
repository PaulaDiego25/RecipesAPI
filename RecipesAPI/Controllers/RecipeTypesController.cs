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
    public class RecipeTypesController : ApiController
    {
        private RecipesAPIContext db = new RecipesAPIContext();

        // GET: api/RecipeTypes
        public IQueryable<RecipeType> GetRecipeTypes()
        {
            return db.RecipeTypes;
        }

        // GET: api/RecipeTypes/5
        [ResponseType(typeof(RecipeType))]
        public async Task<IHttpActionResult> GetRecipeType(int id)
        {
            RecipeType recipeType = await db.RecipeTypes.FindAsync(id);
            if (recipeType == null)
            {
                return NotFound();
            }

            return Ok(recipeType);
        }

        // GET: api/RecipeTypeByCategory/5
        [Route("api/RecipeTypeByCategory")]
        public RecipeType GetRecipeTypeByCategory(int categoryId)
        {           
            Category category = db.Categories.Single(c => c.Id == categoryId);
            RecipeType recipeType = db.RecipeTypes.Single(r => r.Id == category.FKRecipeTypeId);
            recipeType.FKCategories = null;
            return recipeType;
        }


        // PUT: api/RecipeTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRecipeType(int id, RecipeType recipeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipeType.Id)
            {
                return BadRequest();
            }

            db.Entry(recipeType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeTypeExists(id))
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

        // POST: api/RecipeTypes
        [ResponseType(typeof(RecipeType))]
        public async Task<IHttpActionResult> PostRecipeType(RecipeType recipeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecipeTypes.Add(recipeType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = recipeType.Id }, recipeType);
        }

        // DELETE: api/RecipeTypes/5
        [ResponseType(typeof(RecipeType))]
        public async Task<IHttpActionResult> DeleteRecipeType(int id)
        {
            RecipeType recipeType = await db.RecipeTypes.FindAsync(id);
            if (recipeType == null)
            {
                return NotFound();
            }

            db.RecipeTypes.Remove(recipeType);
            await db.SaveChangesAsync();

            return Ok(recipeType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeTypeExists(int id)
        {
            return db.RecipeTypes.Count(e => e.Id == id) > 0;
        }
    }
}