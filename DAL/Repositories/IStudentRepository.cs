using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface IStudentRepository: IGenericRepository<Student>
    {
        Student GetByName(string name);
    }
}
