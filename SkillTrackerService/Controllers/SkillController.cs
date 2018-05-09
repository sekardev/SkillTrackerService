using SkillTrackerDb;
using SkillTrackerDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SkillTrackerService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [System.Web.Http.RoutePrefix("api/skills")]
    public class SkillController : ApiController
    {
        SkillDb dao;
        public SkillController()
        {
            dao = new SkillDb();
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
        [System.Web.Http.Route("search/{skillName}")]
        public IHttpActionResult Get(string skillName)
        {
            try
            {
                return Ok(dao.GetByName(skillName));
            }
            catch (Exception ex)
            {
                return BadRequest("Error Occurred");
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
                return BadRequest("Error Occurred");
            }
        }

       

        // POST: api/Category
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Add/{skillName}/{skillId}")]
        public IHttpActionResult Post(string skillName, int skillId)
        {
            try
            {
                Skills model = new Skills() { SkillId = skillId, SkillName = skillName };
                if (dao.Add(model))
                    return Ok("Record Created Successfully");
                else
                    return BadRequest("Record Created Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Error Occurred");
            }

        }

        // POST: api/Category
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Add")]
        public IHttpActionResult Post(Skills skills)
        {
            try
            {
                Skills model = new Skills() { SkillId = skills.SkillId, SkillName = skills.SkillName, Created = DateTime.Now };
                if (dao.Add(model))
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
        [System.Web.Http.Route("Update")]
        public IHttpActionResult Post(int Id, string skillName)
        {
            try
            {
                Skills model = new Skills()
                {
                    SkillName = skillName,
                    Created = DateTime.Now
                };
                if (dao.Add(model))
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
