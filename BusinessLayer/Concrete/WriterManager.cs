using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDAL;

        public WriterManager(IWriterDAL writerDAL)
        {
            _writerDAL = writerDAL;
        }

        public void TDelete(WriterUser entity)
        {
            _writerDAL.Delete(entity);
        }

        public WriterUser TGetByID(int id)
        {
            return _writerDAL.GetByID(id);
        }

        public List<WriterUser> TGetList(Expression<Func<WriterUser, bool>> filter)
        {
            return _writerDAL.GetList(filter);
        }

        public List<WriterUser> TGetList()
        {
            return _writerDAL.GetList();
        }

        public void TInsert(WriterUser entity)
        {
            _writerDAL.Insert(entity);
        }

        public void TUpdate(WriterUser entity)
        {
            _writerDAL.Update(entity);
        }
    }
}
