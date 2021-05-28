using Core.DataAccess.EntityFramework;
using Core.Entites.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DatabaseContext>, IUserDal
    {
        public UserDto GetUserID(int userID)
        {
            using (DatabaseContext db=new DatabaseContext())
            {
                var result = from user in db.Users
                             join dep in db.DepartmentTypes on
                             user.DepartmentTypeID equals dep.DepartmentTypeID
                             where user.UserID == userID && user.Status == true
                             select new UserDto
                             {
                                 UserID = user.UserID,
                                 Name = user.Name,
                                 Surname = user.Surname,
                                 Email = user.Email,
                                 DepartmentName = dep.DepartmentTypeName,
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
