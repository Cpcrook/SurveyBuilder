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
using CrookSurveyBuilder.Models.Entities;
using WebGrease.Css.Extensions;

namespace CrookSurveyBuilder.Controllers.api
{
    [Authorize]
    public class SurveyResponsesController : ApiController
    {
        private SurveyBuilderContext db = new SurveyBuilderContext();

        // GET: api/SurveyResponses
        public IQueryable<SurveyResponse> GetResponse()
        {
            return db.Response;
        }

        // GET: api/SurveyResponses/5
        [ResponseType(typeof(SurveyResponse))]
        public async Task<IHttpActionResult> GetSurveyResponse(int id)
        {
            SurveyResponse surveyResponse = await db.Response.FindAsync(id);
            if (surveyResponse == null)
            {
                return NotFound();
            }

            return Ok(surveyResponse);
        }

        // PUT: api/SurveyResponses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSurveyResponse(int id, SurveyResponse surveyResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != surveyResponse.SurveyResponseId)
            {
                return BadRequest();
            }

            db.Entry(surveyResponse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyResponseExists(id))
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

        // POST: api/SurveyResponses
        [ResponseType(typeof(SurveyResponse))]
        public async Task<IHttpActionResult> PostSurveyResponse(List<SurveyResponse> surveyResponses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Response.AddRange(surveyResponses);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", surveyResponses.Select(x=> new {id=x.SurveyResponseId}), surveyResponses);
        }

        // DELETE: api/SurveyResponses/5
        [ResponseType(typeof(SurveyResponse))]
        public async Task<IHttpActionResult> DeleteSurveyResponse(int id)
        {
            SurveyResponse surveyResponse = await db.Response.FindAsync(id);
            if (surveyResponse == null)
            {
                return NotFound();
            }

            db.Response.Remove(surveyResponse);
            await db.SaveChangesAsync();

            return Ok(surveyResponse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SurveyResponseExists(int id)
        {
            return db.Response.Count(e => e.SurveyResponseId == id) > 0;
        }
    }
}