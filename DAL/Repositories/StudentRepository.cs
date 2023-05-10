using DAL.EF_Core;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {        
        private readonly MyDBContext _dbContext;
        public StudentRepository(MyDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Student GetByName(string name)
        {
            return _dbContext.Students.Where(item => item.FirstName == name).FirstOrDefault();
        }
    }
}
