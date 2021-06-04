using Rockwood.Data;
using Rockwood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockwood.Services
{
    public class DepartmentService
    {

        public bool CreateNote(DepartmentCreate model)
        {
            var entity =
                new Department()
                {
                    DepartmentTitle = model.DepartmentTitle,                   
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Departments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DepartmentListItem> GetDepartments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Departments  
                        .Select(
                            e =>
                                new DepartmentListItem
                                {
                                    DepartmentId = e.DepartmentId,
                                    DepartmentTitle = e.DepartmentTitle
                                }
                         );
                return query.ToArray();
            }
        }
    }
        
}
