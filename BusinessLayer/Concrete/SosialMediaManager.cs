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
    public class SosialMediaManager : ISosialMediaService
    {
        ISosialMediaDAL _sosialMediaDAL;

        public SosialMediaManager(ISosialMediaDAL sosialMediaDAL)
        {
            _sosialMediaDAL = sosialMediaDAL;
        }

        public void TDelete(SosialMedia entity)
        {
            _sosialMediaDAL.Delete(entity);
        }

        public SosialMedia TGetByID(int id)
        {
            return _sosialMediaDAL.GetByID(id);
        }

        public List<SosialMedia> TGetList()
        {
            return _sosialMediaDAL.GetList();
        }

        public List<SosialMedia> TGetList(Expression<Func<SosialMedia, bool>> filter)
        {
            return _sosialMediaDAL.GetList(filter);
        }

        public void TInsert(SosialMedia entity)
        {
            _sosialMediaDAL.Insert(entity);
        }

        public void TUpdate(SosialMedia entity)
        {
            _sosialMediaDAL.Update(entity);
        }
    }
}
