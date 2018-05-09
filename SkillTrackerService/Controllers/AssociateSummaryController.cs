using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SkillTrackerDb;
using SkillTrackerDb.Model;

namespace SkillTrackerService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [System.Web.Http.RoutePrefix("api/associates")]
    public class AssociateSummaryController : ApiController
    {
        AssociateSummary dao;

        public AssociateSummaryController()
        {
            dao = new AssociateSummary();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("summary")]
        public IHttpActionResult Get()
        {
            try
            {

                return Ok(dao.GetSummary());
            }
            catch (Exception ex)
            {
                return BadRequest("Error Occurred" + ex.InnerException.ToString());
            }

        }

    }
}
