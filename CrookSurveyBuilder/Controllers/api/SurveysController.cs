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
using CrookSurveyBuilder.DAL.Entities;
using CrookSurveyBuilder.Models;
using CrookSurveyBuilder.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WebGrease.Css.Extensions;

namespace CrookSurveyBuilder.Controllers.api
{
    [Authorize]
    public class SurveysController : ApiController
    {
        private SurveyBuilderContext db = new SurveyBuilderContext();

        // GET: api/Surveys
        public IQueryable<Survey> GetSurveys()
        {
            string currentUserId = User.Identity.GetUserId();
            return db.Surveys.Where(x => x.UserId == currentUserId).AsQueryable();
        }

        // GET: api/Surveys/5
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> GetSurvey(int id)
        {
            Survey survey = await db.Surveys.FindAsync(id);
            if (survey == null)
            {
                return NotFound();
            }
            survey.Questions.OrderBy(x => x.Order);
            return Ok(survey);
        }

        // PUT: api/Surveys/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSurvey(int id, Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != survey.SurveyId)
            {
                return BadRequest();
            }

            var dbVersion = db.Surveys
                      .Include(x => x.Questions)
                      .Single(c => c.SurveyId == survey.SurveyId);

            //update individual properties; had trouble getting the associaed questions updating properly without doing it this way.
            dbVersion.Name = survey.Name;
            dbVersion.Description = survey.Description;
            dbVersion.CompletionMessage = dbVersion.CompletionMessage;
            dbVersion.Questions = survey.Questions;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyExists(id))
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

        // POST: api/Surveys
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> PostSurvey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            //Set the UserId manually
            survey.UserId = User.Identity.GetUserId();
            db.Surveys.Add(survey);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = survey.SurveyId }, survey);
        }

        // DELETE: api/Surveys/5
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> DeleteSurvey(int id)
        {
            Survey survey = await db.Surveys.FindAsync(id);
            if (survey == null)
            {
                return NotFound();
            }
            //Remove related entities first to avoid FK constraint issues
            db.Questions.RemoveRange(survey.Questions);
            db.Response.RemoveRange(survey.Responses);

            survey.Questions = null;
            survey.Responses = null;

            db.Surveys.Remove(survey);
            await db.SaveChangesAsync();

            return Ok(survey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SurveyExists(int id)
        {
            return db.Surveys.Count(e => e.SurveyId == id) > 0;
        }
    }
}