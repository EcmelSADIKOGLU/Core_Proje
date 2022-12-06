using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T entity);
        void TUpdate(T entity);
        List<T> TGetList(Expression<Func<T, bool>> filter);
        void TDelete(T entity);
        List<T> TGetList();
        T TGetByID(int id);
    }
}
