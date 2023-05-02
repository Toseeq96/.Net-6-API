using BLL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net_6_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IGenericRepository<Teacher> _repoTeaher;

        public TeacherController(IGenericRepository<Teacher> repoTeaher)
        {
            _repoTeaher = repoTeaher;
        }

        [Route("GetAllTeachers")]
        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            return Ok(await _repoTeaher.GetAllAsync());
        }

        [Route("GetTeacherById")]
        [HttpGet]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            return Ok(await _repoTeaher.GetByIdAsync(id));
        }

        [Route("InsertTeacher")]
        [HttpGet]
        public void InsertTeacher(Teacher teacher)
        {
            _repoTeaher.Insert(teacher);
        }

        [Route("UpdateTeacher")]
        [HttpGet]
        public void UpdateTeacher(Teacher teacher)
        {
            _repoTeaher.Update(teacher);
        }

        [Route("DeleteTeacherById")]
        [HttpGet]
        public async void DeleteTeacherById(int id)
        {
            var getTeacher = await _repoTeaher.GetByIdAsync(id);
            _repoTeaher.Delete(getTeacher);
        }

        [Route("GetTeacherByName")]
        [HttpGet]
        public IActionResult GetTeacherByName(string name)
        {
            return Ok(_repoTeaher.GetQueryable().Where(x => x.FirstName == name).SingleOrDefault());
        }
    }
}
