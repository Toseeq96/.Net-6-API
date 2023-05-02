using BLL.Repositories;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net_6_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _serviceStudent;        
        public StudentController(IStudentService serviceStudent)
        {
            _serviceStudent = serviceStudent;
        }

        [Route("GetAllStudents")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await _serviceStudent.GetAll());
        }

        [Route("GetStudentById")]
        [HttpGet]
        public IActionResult GetStudentById(int id)
        {
            return Ok( _serviceStudent.GetById(id));
        } 
        
        [Route("InsertStudent")]
        [HttpPost]
        public void InsertStudent(Student student)
        {
            _serviceStudent.Insert(student);
        } 
        
        [Route("UpdateStudentById")]
        [HttpPut]
        public async Task UpdateStudentById(Student student)
        {
           await _serviceStudent.Update(student);
        } 
        
        [Route("DeleteStudentById")]
        [HttpDelete]
        public void DeleteStudentById(int id)
        {
             _serviceStudent.Delete(id);
        }
    }
}
