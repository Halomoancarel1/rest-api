using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest_api.Models.DBModels;

namespace rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private jobContext _context;

        public ValuesController(jobContext context)
        {
            this._context = context;
        }


        // Get All Todo’s
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var students = _context.Task.ToList();
            return Ok(students);
        }

        // Get Specific Todo
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var studentById = (from a in _context.Task
                               where a.Id == id
                               select new jobTask
                               {
                                   Id = a.Id,
                                   Title = a.Title,
                                   Description = a.Description,
                                   IsComplete = a.IsComplete,
                                   CreatedDate = a.CreatedDate,
                                   Percentage = a.Percentage
                               }).FirstOrDefault();
            return Ok(studentById);
        }

        //Get Incoming ToDo
        [HttpGet("{startDate}/{endDate}")]
        public ActionResult<string> GetByDate(DateTime startDate, DateTime endDate)
        {
            var studentByDate = (from a in _context.Task
                               where (DateTime.Parse(a.CreatedDate.ToString("yyyy-MM-dd")) >= startDate) && (DateTime.Parse(a.CreatedDate.ToString("yyyy-MM-dd")) <= endDate)
                               select new jobTask
                               {
                                   Id = a.Id,
                                   Title = a.Title,
                                   Description = a.Description,
                                   IsComplete = a.IsComplete,
                                   CreatedDate = a.CreatedDate,
                                   Percentage = a.Percentage
                               }).ToList();
            return Ok(studentByDate);
        }

        // Create Todo
        [HttpPost]
        public void Post([FromBody] jobTask model)
        {
            model.CreatedDate = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();
        }

        // Update Todo
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] jobTask model)
        {
            var single = (from a in _context.Task
                          where a.Id == id
                          select new jobTask
                          {
                              Id = a.Id,
                              Title = a.Title,
                              Description = a.Description,
                              IsComplete = a.IsComplete,
                              CreatedDate = a.CreatedDate,
                              Percentage = a.Percentage
                          }).FirstOrDefault();
            if(single != null)
            {
                single.IsComplete = model.IsComplete;
                single.Title = model.Title;
                single.Description = model.Description;
                single.Percentage = model.Percentage;
            }
            _context.Update(single);
            _context.SaveChanges();

        }

        // Delete Todo
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var single = (from a in _context.Task
                          where a.Id == id
                          select new jobTask 
                          {
                              Id = a.Id,
                          }).FirstOrDefault();

            _context.Task.Remove(single);
            _context.SaveChanges();
        }

        //Mark Todo as Done
        [HttpPut("{id}/{status}")]
        public void Put(int id, bool status)
        {
            var single = (from a in _context.Task
                          where a.Id == id
                          select new jobTask
                          {
                              Id = a.Id,
                              Title = a.Title,
                              Description = a.Description,
                              IsComplete = a.IsComplete,
                              CreatedDate = a.CreatedDate,
                              Percentage = a.Percentage
                          }).FirstOrDefault();
            if (single != null)
            {
                single.IsComplete = status;
            }
            _context.Update(single);
            _context.SaveChanges();

        }
        //Set Todo percent complete
        [HttpPut("{id}/{percentage}")]
        public void updateData(int id, decimal percentage)
        {
            var single = (from a in _context.Task
                          where a.Id == id
                          select new jobTask
                          {
                              Id = a.Id,
                              Title = a.Title,
                              Description = a.Description,
                              IsComplete = a.IsComplete,
                              CreatedDate = a.CreatedDate,
                              Percentage = a.Percentage
                          }).FirstOrDefault();
            if (single != null)
            {
                if(percentage == 100)
                {
                    single.IsComplete = true;
                    single.Percentage = percentage;
                }
                else
                {
                    single.Percentage = percentage;
                }
                
            }
            _context.Update(single);
            _context.SaveChanges();

        }
    }
}
