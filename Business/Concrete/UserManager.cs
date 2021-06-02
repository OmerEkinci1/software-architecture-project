using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entites.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;


        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public IResult Delete(User user)
        {
            var getUser = GetByMail(user.Email).Data;
            user.DepartmentTypeID = getUser.DepartmentTypeID;
            user.PasswordHash = getUser.PasswordHash;
            user.PasswordSalt = getUser.PasswordSalt;
            user.Status = false;            
            _userDal.Update(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        public IResult Update(User user)
        {
            var getUser = GetByMail(user.Email).Data;
            user.DepartmentTypeID = getUser.DepartmentTypeID;
            user.PasswordHash = getUser.PasswordHash;
            user.PasswordSalt = getUser.PasswordSalt;
            user.Status = getUser.Status;
       
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email && u.Status == true));
        }

        [CacheAspect(duration: 10)]
        public IDataResult<UserDto> GetById(int userID)
        {
            return new SuccessDataResult<UserDto>(_userDal.GetUserID(userID));

        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<User>> GetUserByStatusTrue()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAllUserByStatusTrue());
        }
    }
}
