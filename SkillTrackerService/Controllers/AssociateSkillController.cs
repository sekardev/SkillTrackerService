using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SkillTrackerDb;
using SkillTrackerDb.Model;
using Newtonsoft.Json;

namespace SkillTrackerService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [System.Web.Http.RoutePrefix("api/associate")]
    public class AssociateSkillController : ApiController
    {
        AssociateSkillDb dao;
        // GET: AssociateSkills

        public AssociateSkillController()
        {
            dao = new AssociateSkillDb();
        }
        // GET: api/Skills

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(dao.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest("Error Occurred" + ex.InnerException.ToString());
            }

        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(dao.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Error Occurred" + ex.InnerException.ToString());
            }

        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("skill/{id}")]
        public IHttpActionResult GetAssociate_Skill(int id)
        {
            try
            {
                return Ok(dao.CheckAssociateSkill(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Error Occurred");
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Add")]
        public IHttpActionResult Post(HttpRequestMessage jsonData)
        {
            try
            {
                AssociateVM associate = JsonConvert.DeserializeObject<AssociateVM>(jsonData.Content.ReadAsStringAsync().Result);
                if (dao.Add(associate))
                    return Ok("Record Created Successfully");
                else
                    return BadRequest("Record Created Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Error Occurred");
            }

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Delete/{id}")]
        public IHttpActionResult Post(int id)
        {
            try
            {
                if (dao.Delete(id))
                    return Ok("Record Deleted Successfully");
                else
                    return BadRequest("Error Occurred");
            }
            catch (Exception ex)
            {
                return BadRequest("Error Occurred");
            }
        }


    }
}
