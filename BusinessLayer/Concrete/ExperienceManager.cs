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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDAL _experienceDAL;

        public ExperienceManager(IExperienceDAL experienceDAL)
        {
            _experienceDAL = experienceDAL;
        }

        public void TDelete(Experience entity)
        {
            _experienceDAL.Delete(entity);
        }

        public Experience TGetByID(int id)
        {
            return _experienceDAL.GetByID(id);
        }

        public List<Experience> TGetList()
        {
           return _experienceDAL.GetList();
        }

        public List<Experience> TGetList(Expression<Func<Experience, bool>> filter)
        {
            return _experienceDAL.GetList(filter);
        }

        public void TInsert(Experience entity)
        {
            _experienceDAL.Insert(entity);
        }

        public void TUpdate(Experience entity)
        {
            _experienceDAL.Update(entity);
        }
    }
}
