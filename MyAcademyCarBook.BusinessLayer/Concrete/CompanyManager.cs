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
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public void TDelete(Company entity)
        {
            _companyDal.Delete(entity);
        }

        public Company TGetByID(int id)
        {
            return _companyDal.GetByID(id);
        }

        public List<Company> TGetListAll()
        {
            return _companyDal.GetListAll();
        }

        public void TInsert(Company entity)
        {
            _companyDal.Insert(entity);
        }

        public void TUpdate(Company entity)
        {
            _companyDal.Update(entity);
        }
    }
}
