﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IRepository<T>
    {
        List<T> list();
        void İnsert(T p);
        T Get(Expression<Func<T, bool>> filter);
        void Update(T p);
        void Delete(T p);
        List<T> list(Expression<Func<T, bool>> filter);
    }
}
