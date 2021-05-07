using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DepartmentTypeManager : IDepartmentTypeService
    {
        private IDepartmentTypeService _departmentTypeService;

        public DepartmentTypeManager(IDepartmentTypeService departmentTypeService)
        {
            _departmentTypeService = departmentTypeService;
        }
    }
}
