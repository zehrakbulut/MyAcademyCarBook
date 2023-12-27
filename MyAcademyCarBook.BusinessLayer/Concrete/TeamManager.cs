using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public void TDelete(Team entity)
        {
            _teamDal.Delete(entity);    
        }

        public Team TGetByID(int id)
        {
            return _teamDal.GetByID(id);
        }

        public List<Team> TGetListAll()
        {
            return _teamDal.GetListAll();
        }

        public void TInsert(Team entity)
        {
            _teamDal.Insert(entity);
        }

        public void TUpdate(Team entity)
        {
            _teamDal.Update(entity);
        }
    }
}
