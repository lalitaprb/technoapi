using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using testapi.Models;

namespace testapi.Controllers
{
    public class JobsController : ApiController
    {
        private JobModel db = new JobModel();

        // GET: api/Jobs
        public IQueryable<Job> GetJobs()
        {
            return db.Jobs;
        }

        // GET: api/Jobs/5
        [ResponseType(typeof(Job))]
        public IHttpActionResult GetJob(int id)
        {
            
            //if (job == null)
            //{
            //    return NotFound();
            //}

            //return Ok(job);

            JobModel db = new JobModel();
            List<Job> ljobs = db.Jobs.ToList();
            List<Location> llocation = db.Locations.ToList();
            List<Department> ldept = db.Departments.ToList();

            var query = from J in ljobs
                        join LO in llocation on J.LocationId equals LO.Id into table1
                        from LO in table1.DefaultIfEmpty()
                        join De in ldept on J.departmentId equals De.Id into table2
                        from De in table2.DefaultIfEmpty()
                        where J.Id==id
                        select new Jobdetail { jobs = J, location = LO, department = De } ;

            return Ok(query);
        }


        // POST: api/Jobs
        [ResponseType(typeof(Job))]
        public IHttpActionResult Post([FromBody] Job Job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Job.Title.ToString()== "Software Developer")
            {
                Job.code = "JOB-001";
            }
            else if (Job.Title.ToString() == "Project Manager")
            {
                Job.code = "JOB-002";
            }
            else
            {
                Job.code = "JOB-000";
            }
            db.Jobs.Add(Job);
            db.SaveChanges();
            // return CreatedAtRoute("DefaultApi", new { id = Job.Id }, Job);
           

            return  Ok("201"+"  " + new Uri(Request.RequestUri + "/" + Job.Id));
        }

        // PUT: api/Jobs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJob(int id, Job job)
        {
           
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            
                var existingJob = db.Jobs.Where(s => s.Id == id)
                                                        .FirstOrDefault<Job>();

                if (existingJob != null)
                {
                existingJob.Title = job.Title;
                existingJob.Description = job.Description;
                existingJob.LocationId = job.LocationId;
                existingJob.departmentId = job.departmentId;
                existingJob.closingdate = job.closingdate;
                db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }


            return Ok("200 OK");
        }

        [Route("api/Jobs/List")]
        public IHttpActionResult PostList([FromBody] Job Job)
        {
            JobModel db = new JobModel();
            List<Job> ljobs = db.Jobs.ToList();
            List<Location> llocation = db.Locations.ToList();
            List<Department> ldept = db.Departments.ToList();

            var query = from J in ljobs
                        join LO in llocation on J.LocationId equals LO.Id into table1
                        from LO in table1.DefaultIfEmpty()
                        join De in ldept on J.departmentId equals De.Id into table2
                        from De in table2.DefaultIfEmpty()
                        where J.code == Job.code
                        select new  { J.Id,J.code,J.Title,J.LocationId,J.departmentId,J.posteddate,J.closingdate};

            return Ok(query);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobExists(int id)
        {
            return db.Jobs.Count(e => e.Id == id) > 0;
        }
    }
}