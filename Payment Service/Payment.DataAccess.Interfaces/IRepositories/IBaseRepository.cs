﻿using System.Collections.Generic;

namespace Payment.DataAccess.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        object Insert(T entity);
        object Update(T entity);
        object Delete(T entity);
    }
}