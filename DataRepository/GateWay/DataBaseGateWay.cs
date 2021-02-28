using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.GateWay
{
    public abstract class DataBaseGateWay
    {
       protected DbConext dbConext = new DbConext();


        protected void Add(Model model)
        {
            dbConext.Entry(model).State = EntityState.Added;

            dbConext.SaveChanges();
        }
        protected void Edit(Model model)
        {
            dbConext.Entry(model).State = EntityState.Modified;

            dbConext.SaveChanges();
        }

        protected void Delete(Model model)
        {
            dbConext.Entry(model).State = EntityState.Deleted;

            dbConext.SaveChanges();
        }
        public abstract List<object> List();
          




    }
    
}
