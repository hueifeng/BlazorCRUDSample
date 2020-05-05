using BlazorServerCRUDSample.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorServerCRUDSample.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly Shared.Data.AppContext _dbcontext;

        public StudentController(Shared.Data.AppContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _dbcontext.Students.ToList();
        }
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _dbcontext.Students.Find(id);
        }
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            student.CreateTime = DateTime.Now;
            if (ModelState.IsValid)
                _dbcontext.Add(student);
            _dbcontext.SaveChanges();
        }
        [HttpPut]
        public void Put([FromBody] Student student)
        {
            if (ModelState.IsValid)
                _dbcontext.Update(student);
            _dbcontext.SaveChanges();
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            var entity = _dbcontext.Students.Find(id);
            _dbcontext.Students.Remove(entity);
            _dbcontext.SaveChanges();
        }



    }
}
