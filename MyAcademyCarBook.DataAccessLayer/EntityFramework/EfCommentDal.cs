﻿using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.Repositories;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {


        public List<Comment> GetCommentByCar(int id)
        {
            //CarBookContext context=new CarBookContext();
            var context=new CarBookContext();
            var values = context.Comments.Where(x => x.CarID == id).ToList();
            return values;
        }
    }
}
    