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
    public class SkillManager : ISkillService
    {
        ISkillDAL _skillDAL;

        public SkillManager(ISkillDAL skillDAL)
        {
            _skillDAL = skillDAL;
        }

        public void TDelete(Skill entity)
        {
            _skillDAL.Delete(entity);
        }

        public Skill TGetByID(int id)
        {
            return _skillDAL.GetByID(id);
        }

        public List<Skill> TGetList()
        {
            return _skillDAL.GetList();
        }

        public List<Skill> TGetList(Expression<Func<Skill, bool>> filter)
        {
            return _skillDAL.GetList(filter);
        }

        public void TInsert(Skill entity)
        {
            _skillDAL.Insert(entity);
        }

        public void TUpdate(Skill entity)
        {
            _skillDAL.Update(entity);
        }
    }
}
