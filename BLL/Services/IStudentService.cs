using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Student GetByName(string name);
        void Insert(Student student);
        void Update(Student student);
        Task Delete(int id);
    }
}
