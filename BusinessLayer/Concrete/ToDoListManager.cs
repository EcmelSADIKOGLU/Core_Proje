using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ToDoListManager : IToDoListService
    {
        IToDoListDAL _toDoListDAL;

        public ToDoListManager(IToDoListDAL toDoListDAL)
        {
            _toDoListDAL = toDoListDAL;
        }

        public void TDelete(ToDoList entity)
        {
            _toDoListDAL.Delete(entity);
        }

        public ToDoList TGetByID(int id)
        {
            return _toDoListDAL.GetByID(id);
        }

        public List<ToDoList> TGetList()
        {
            return _toDoListDAL.GetList();  
        }

        public List<ToDoList> TGetList(Expression<Func<ToDoList, bool>> filter)
        {
            return _toDoListDAL.GetList(filter);
        }

        public void TInsert(ToDoList entity)
        {
            _toDoListDAL.Insert(entity);
        }

        public void TUpdate(ToDoList entity)
        {
            _toDoListDAL.Update(entity);
        }
    }
}
