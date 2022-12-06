using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.EntitiyFramework;
using DataAccsessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDAL _announcementDAL;

        public AnnouncementManager(IAnnouncementDAL announcementDAL)
        {
            _announcementDAL = announcementDAL;
        }

        public void TDelete(Announcement entity)
        {
            _announcementDAL.Delete(entity);
        }

        public Announcement TGetByID(int id)
        {
            return _announcementDAL.GetByID(id);
        }

        public List<Announcement> TGetList()
        {
            return _announcementDAL.GetList();
        }

        public List<Announcement> TGetList(Expression<Func<Announcement, bool>> filter)
        {
            return _announcementDAL.GetList(filter);
        }

        public void TInsert(Announcement entity)
        {
            _announcementDAL.Insert(entity);
        }

        public void TUpdate(Announcement entity)
        {
            _announcementDAL.Update(entity);
        }
    }
}
