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
    public class PortfolioManager:IPortfolioService
    {
        IPortfolioDAL _portfolioDAL;

        public PortfolioManager(IPortfolioDAL portfolioDAL)
        {
            _portfolioDAL = portfolioDAL;
        }

        public void TDelete(Portfolio entity)
        {
            _portfolioDAL.Delete(entity);
        }

        public Portfolio TGetByID(int id)
        {
            return _portfolioDAL.GetByID(id);
        }

        public List<Portfolio> TGetList()
        {
            return _portfolioDAL.GetList();
        }

        public List<Portfolio> TGetList(Expression<Func<Portfolio, bool>> filter)
        {
            return _portfolioDAL.GetList(filter);
        }

        public void TInsert(Portfolio entity)
        {
            _portfolioDAL.Insert(entity);
        }

        public void TUpdate(Portfolio entity)
        {
            _portfolioDAL.Update(entity);
        }
    }
}
