using DAL.EF_Core;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDBContext _dbContext;
        public StudentRepository(MyDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void Delete(Student student)
        {            
            _dbContext.Remove(student);
            _dbContext.SaveChanges();
        }

        public async Task<List<Student>> GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _dbContext.Students.Where(x => x.StudentId == id).SingleOrDefaultAsync();
        }

        public void Insert(Student student)
        {
             _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public async Task Update(Student student)
        {
            var getStudent = await _dbContext.Students.Where(x => x.StudentId == student.StudentId).SingleAsync();
            if (getStudent != null)
            {
                getStudent.FirstName = student.FirstName;
                getStudent.LastName = student.LastName;
                
                _dbContext.Update(getStudent);
                _dbContext.SaveChanges();
            }           
            
        }
    }
}
