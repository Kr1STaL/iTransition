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
using iTransition.Models;

namespace iTransition.Controllers
{
    public class SitesController : ApiController
    {
        private iTransitionContext db = new iTransitionContext();

        // GET: api/Sites
        public IQueryable<SiteDTO> GetSites()
        {
            var sites = from b in db.Sites
                        select new SiteDTO()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            UserName = b.User.Name
                        };
            return sites;
        }

        // GET: api/Sites/5
        [ResponseType(typeof(SiteDetailDTO))]
        public async Task<IHttpActionResult> GetSite(int id)
        {
            var site = await db.Sites.Include(b => b.User).Select(b =>
            new SiteDetailDTO()
            {
                Id = b.Id,
                Title = b.Title,
                Year = b.Year,
                UserName = b.User.Name,
                Description = b.Description
            }).SingleOrDefaultAsync(b => b.Id == id);
            if (site == null)
            {
                return NotFound();
            }

            return Ok(site);
        }

        // PUT: api/Sites/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSite(int id, Site site)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != site.Id)
            {
                return BadRequest();
            }

            db.Entry(site).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteExists(id))
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

        // POST: api/Sites
        [ResponseType(typeof(Site))]
        public async Task<IHttpActionResult> PostSite(Site site)
        {   
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sites.Add(site);
            await db.SaveChangesAsync();

            db.Entry(site).Reference(x => x.User).Load();

            var dto = new SiteDTO()
            {
                Id = site.Id,
                Title = site.Title,
                UserName = site.User.Name
            };

            return CreatedAtRoute("DefaultApi", new { id = site.Id }, dto);
        }

        // DELETE: api/Sites/5
        [ResponseType(typeof(Site))]
        public async Task<IHttpActionResult> DeleteSite(int id)
        {
            Site site = await db.Sites.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }

            db.Sites.Remove(site);
            await db.SaveChangesAsync();

            return Ok(site);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SiteExists(int id)
        {
            return db.Sites.Count(e => e.Id == id) > 0;
        }
    }
}