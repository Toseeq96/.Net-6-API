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
        [HttpPost]
        public void InsertTeacher(Teacher teacher)
        {
            _repoTeaher.Insert(teacher);
            _repoTeaher.SaveChangesAsync();
        }

        [Route("UpdateTeacher")]
        [HttpPut]
        public void UpdateTeacher(Teacher teacher)
        {
            _repoTeaher.Update(teacher);
            _repoTeaher.SaveChangesAsync();
        }

        [Route("DeleteTeacherById")]
        [HttpDelete]
        public async void DeleteTeacherById(int id)
        {
            var getTeacher = await _repoTeaher.GetByIdAsync(id);
            if(getTeacher != null)
            _repoTeaher.Delete(getTeacher);
           await _repoTeaher.SaveChangesAsync();
        }

        [Route("GetTeacherByName")]
        [HttpGet]
        public IActionResult GetTeacherByName(string name)
        {
            return Ok(_repoTeaher.GetQueryable().Where(x => x.FirstName == name).SingleOrDefault());
        }
    }
}
