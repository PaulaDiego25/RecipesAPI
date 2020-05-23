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
    public class UserRecipesController : ApiController
    {
        private RecipesAPIContext db = new RecipesAPIContext();

        // GET: api/UserRecipes
        public IQueryable<UserRecipeRating> GetUserRecipes()
        {
            return db.UserRecipeRatings;
        }

        // GET: api/UserRecipes/5
        [ResponseType(typeof(UserRecipeRating))]
        public async Task<IHttpActionResult> GetUserRecipe(int id)
        {
            UserRecipeRating userRecipe = await db.UserRecipeRatings.FindAsync(id);
            if (userRecipe == null)
            {
                return NotFound();
            }

            return Ok(userRecipe);
        }

        // PUT: api/UserRecipes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserRecipe(int id, UserRecipeRating userRecipeRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userRecipeRating.Id)
            {
                return BadRequest();
            }

            db.Entry(userRecipeRating).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRecipeExists(id))
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

        // POST: api/UserRecipes
        [ResponseType(typeof(UserRecipeRating))]
        public async Task<IHttpActionResult> PostUserRecipe(UserRecipeRating userRecipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserRecipeRatings.Add(userRecipe);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userRecipe.Id }, userRecipe);
        }

        // DELETE: api/UserRecipes/5
        [ResponseType(typeof(UserRecipeRating))]
        public async Task<IHttpActionResult> DeleteUserRecipe(int id)
        {
            UserRecipeRating userRecipe = await db.UserRecipeRatings.FindAsync(id);
            if (userRecipe == null)
            {
                return NotFound();
            }

            db.UserRecipeRatings.Remove(userRecipe);
            await db.SaveChangesAsync();

            return Ok(userRecipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserRecipeExists(int id)
        {
            return db.UserRecipeRatings.Count(e => e.Id == id) > 0;
        }
    }
}