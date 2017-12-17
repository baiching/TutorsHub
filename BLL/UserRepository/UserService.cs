using System;
using System.Collections.Generic;
using DLL.LogContext;
using DLL.UserContext;
using Entity.Logs;
using Entity.UserModels;

namespace BLL.UserRepository
{
    public class UserService<T> where T : User
    {
        public T GetByEmail(string email)
        {
            return new UserRepository<T>().GetByEmail(email);
        }

        public List<T> GetAll()
        {
            return new UserRepository<T>().GetAll();
        }

        public bool Add(T t)
        {
            return new UserRepository<T>().Add(t);
        }

        public bool Update(T t)
        {
            return new UserRepository<T>().Update(t);
        }

        public bool Remove(string userName)
        {
            return new UserRepository<T>().Remove(userName);
        }

        public bool ValidUser(string email, string password)
        {
            var user = GetByEmail(email);
            if (user == null) return false;

            user.LastLogin=DateTime.Now;
            Update(user);
            new LogRepository<UserLog>().Add(new UserLog()
            {
                LogDateTime = DateTime.Now,
                Role = user.Role
            });
            return user.Password == password;
        }

        public bool UpdatePassword(string email, string password)
        {
            return new UserRepository<T>().UpdatePassword(email,password);
        }




    }
}
