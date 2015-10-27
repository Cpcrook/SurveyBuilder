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

namespace CrookSurveyBuilder.Controllers.api
{
    [Authorize]
    public class SurveyQuestionsController : ApiController
    {
        private SurveyBuilderContext db = new SurveyBuilderContext();

        // GET: api/SurveyQuestions
        public IQueryable<SurveyQuestion> GetQuestions()
        {
            return db.Questions;
        }

        // GET: api/SurveyQuestions/5
        [ResponseType(typeof(SurveyQuestion))]
        public async Task<IHttpActionResult> GetSurveyQuestion(int id)
        {
            SurveyQuestion surveyQuestion = await db.Questions.FindAsync(id);
            if (surveyQuestion == null)
            {
                return NotFound();
            }

            return Ok(surveyQuestion);
        }

        // PUT: api/SurveyQuestions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSurveyQuestion(int id, SurveyQuestion surveyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != surveyQuestion.SurveyQuestionId)
            {
                return BadRequest();
            }

            db.Entry(surveyQuestion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyQuestionExists(id))
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

        // POST: api/SurveyQuestions
        [ResponseType(typeof(SurveyQuestion))]
        public async Task<IHttpActionResult> PostSurveyQuestion(SurveyQuestion surveyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Questions.Add(surveyQuestion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = surveyQuestion.SurveyQuestionId }, surveyQuestion);
        }

        // DELETE: api/SurveyQuestions/5
        [ResponseType(typeof(SurveyQuestion))]
        public async Task<IHttpActionResult> DeleteSurveyQuestion(int id)
        {
            SurveyQuestion surveyQuestion = await db.Questions.FindAsync(id);
            if (surveyQuestion == null)
            {
                return NotFound();
            }

            db.Questions.Remove(surveyQuestion);
            await db.SaveChangesAsync();

            return Ok(surveyQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SurveyQuestionExists(int id)
        {
            return db.Questions.Count(e => e.SurveyQuestionId == id) > 0;
        }
    }
}