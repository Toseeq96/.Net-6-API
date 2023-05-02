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

        public void Delete(int id)
        {
            var getStudent = _repoStudent.GetById(id);
            if( getStudent != null)
            _repoStudent.Delete(getStudent);
        }

        public async Task<List<Student>> GetAll()
        {
            return await _repoStudent.GetAll();
        }

        public Student GetById(int id)
        {
            return _repoStudent.GetById(id);    
        }

        public void Insert(Student student)
        {
            _repoStudent.Insert(student);
        }

        public async Task Update(Student student)
        {
            await _repoStudent.Update(student);
        }
    }
}
