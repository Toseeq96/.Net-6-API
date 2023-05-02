using BLL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net_6_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repoStudent;
        public StudentController(IStudentRepository repoStudent)
        {
            _repoStudent = repoStudent;
        }

        [Route("GetAllStudents")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await _repoStudent.GetAll());
        }

        [Route("GetStudentById")]
        [HttpGet]
        public async Task<IActionResult> GetStudentById(int id)
        {
            return Ok(await _repoStudent.GetById(id));
        } 
        
        [Route("InsertStudent")]
        [HttpPost]
        public void InsertStudent(Student student)
        {
            _repoStudent.Insert(student);
        } 
        
        [Route("UpdateStudentById")]
        [HttpPut]
        public async Task UpdateStudentById(Student student)
        {
           await _repoStudent.Update(student);
        } 
        
        [Route("DeleteStudentById")]
        [HttpDelete]
        public void DeleteStudentById(int id)
        {
             _repoStudent.Delete(id);
        }
    }
}
