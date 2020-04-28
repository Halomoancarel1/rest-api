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
        private sekolahContext _context;

        public ValuesController(sekolahContext context)
        {
            this._context = context;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var students = _context.Siswa.ToList();
            return Ok(students);
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var studentById = (from a in _context.Siswa
                               where a.Id == id
                               select new Siswa
                               {
                                   Nama = a.Nama,
                                   Alamat = a.Alamat
                               }).FirstOrDefault();
            return Ok(studentById);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
