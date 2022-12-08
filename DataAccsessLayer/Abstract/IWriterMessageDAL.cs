using DataAccsessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Abstract
{
    public interface IWriterMessageDAL:IGenericDAL<WriterMessage>
    {
        String GetNameByMail(string mail);
        List<WriterMessage> GetMessageListWithSender(string mail);
    }
}
