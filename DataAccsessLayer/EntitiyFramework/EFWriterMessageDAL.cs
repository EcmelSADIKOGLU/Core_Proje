using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.EntitiyFramework
{
    public class EFWriterMessageDAL : GenericRepository<WriterMessage>, IWriterMessageDAL
    {
        Context context = new Context();

        public List<WriterMessage> GetMessageListWithSender(string mail)
        {
            throw new NotImplementedException();
        }

        public String GetNameByMail(string mail)
        {
           var user = context.Users.Where(x => x.Email == mail).FirstOrDefault();
            if (user == null)
            {
                return "Yanlış mail";
            }
            return user.Name + " " + user.Surname;
        }

        
    }
}
