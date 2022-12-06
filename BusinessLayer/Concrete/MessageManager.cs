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
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public void TDelete(Message entity)
        {
            _messageDAL.Delete(entity);
        }

        public Message TGetByID(int id)
        {
            return _messageDAL.GetByID(id);
        }

        public List<Message> TGetList()
        {
            return _messageDAL.GetList();
        }

        public List<Message> TGetList(Expression<Func<Message, bool>> filter)
        {
            return _messageDAL.GetList(filter);
        }

        public void TInsert(Message entity)
        {
            _messageDAL.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
            _messageDAL.Update(entity);
        }
    }
}
