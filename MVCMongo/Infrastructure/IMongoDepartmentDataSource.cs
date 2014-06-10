using MVCMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMongo.Infrastructure
{
    public interface IMongoDepartmentDataSource : IDisposable
    {
        List<Department> Departments { get; }
        void CreateDepartment(Department colleciton);
        void EditDepartment(Department collection);
        void DeleteDepartment(Department collection);
    }

}
