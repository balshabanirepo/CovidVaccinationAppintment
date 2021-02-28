using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataRepository.GateWay
{
    internal class DataBaseGateWay<Tentity>:RecordListInterface<Tentity> where Tentity:class
    {
        DbConext dbConext = new DbConext();


        internal  void Add(Model model)
        {
            dbConext.Entry(model).State = EntityState.Added;

            dbConext.SaveChanges();
        }
        internal  void Edit(Model model)
        {
            dbConext.Entry(model).State = EntityState.Modified;

            dbConext.SaveChanges();
        }

        internal  void Delete(Model model)
        {
            dbConext.Entry(model).State = EntityState.Deleted;

            dbConext.SaveChanges();
        }

        internal Tentity GetById(Expression<Func<Tentity, bool>> predicate)
        {
            return dbConext.Set<Tentity>().Where(predicate).FirstOrDefault();

           
        }

        internal List<Tentity> List()
        {
          return  dbConext.Set<Tentity>().ToList();

           
        }






    }
    
}
