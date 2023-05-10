using BLL.Repositories;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repoStudent;

        public StudentService(IStudentRepository repoStudent)
        {
            _repoStudent = repoStudent;
        }

        public async Task Delete(int id)
        {
            var getStudent = await _repoStudent.GetByIdAsync(id);
            if( getStudent != null)
            _repoStudent.Delete(getStudent);
        }

        public async Task<List<Student>> GetAll()
        {
            return await _repoStudent.GetAllAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _repoStudent.GetByIdAsync(id);    
        }

        public void Insert(Student student)
        {            
             _repoStudent.Insert(student);                      
        }

        public void Update(Student student)
        {
             _repoStudent.Update(student);
        }

        public Student GetByName(string name)
        {
            return _repoStudent.GetByName(name);
        }
    }
}
