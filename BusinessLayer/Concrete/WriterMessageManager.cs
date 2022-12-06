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
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDAL _writerMessageDAL;

        public WriterMessageManager(IWriterMessageDAL writerMessageDAL)
        {
            _writerMessageDAL = writerMessageDAL;
        }

        public void TDelete(WriterMessage entity)
        {
            _writerMessageDAL.Delete(entity);
        }

        public WriterMessage TGetByID(int id)
        {
            return _writerMessageDAL.GetByID(id);
        }

        public List<WriterMessage> TGetList()
        {
            return _writerMessageDAL.GetList();
        }

        public List<WriterMessage> TGetList(Expression<Func<WriterMessage, bool>> filter)
        {
            return _writerMessageDAL.GetList(filter);
        }

        public string TGetNameByMail(string mail)
        {
            return _writerMessageDAL.GetNameByMail(mail);
        }

        public void TInsert(WriterMessage entity)
        {
            _writerMessageDAL.Insert(entity);
        }

        public void TUpdate(WriterMessage entity)
        {
            _writerMessageDAL.Update(entity);
        }
    }
}
