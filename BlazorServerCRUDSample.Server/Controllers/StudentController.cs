using BlazorServerCRUDSample.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<List<Student>> Get()
        {
            return await _dbcontext.Students.AsQueryable().ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            return await _dbcontext.Students.FindAsync(id);
        }
        [HttpPost]
        public async Task Post([FromBody] Student student)
        {
            student.CreateTime = DateTime.Now;
            if (ModelState.IsValid)
                await _dbcontext.AddAsync(student);
           await _dbcontext.SaveChangesAsync();
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
