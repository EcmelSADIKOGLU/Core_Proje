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
    public class ContectManager : IContectService
    {
        private readonly IContectDAL _contectDAL;

        public ContectManager(IContectDAL contectDAL)
        {
            _contectDAL = contectDAL;
        }

        public void TDelete(Contect entity)
        {
            _contectDAL.Delete(entity);
        }

        public Contect TGetByID(int id)
        {
            return _contectDAL.GetByID(id);
        }

        public List<Contect> TGetList()
        {
            return _contectDAL.GetList();
        }

        public List<Contect> TGetList(Expression<Func<Contect, bool>> filter)
        {
            return _contectDAL.GetList(filter);
        }

        public void TInsert(Contect entity)
        {
            _contectDAL.Insert(entity);
        }

        public void TUpdate(Contect entity)
        {
            _contectDAL.Update(entity);
        }
    }
}
