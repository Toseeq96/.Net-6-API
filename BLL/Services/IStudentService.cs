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
        Student GetById(int id);
        void Insert(Student student);
        Task Update(Student student);
        void Delete(int id);
    }
}
